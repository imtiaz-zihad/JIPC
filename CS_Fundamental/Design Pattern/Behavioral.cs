// -----------Behavioral Design Pattern-----------

// 1. Command Pattern → Encapsulates a request as an object, thereby allowing for parameterization of clients with queues, requests, and operations.

public interface ICommand
{
    void Execute();
}
// receiver
public class BankAccount
{
    private decimal _balance;
    public BankAccount(decimal initialBalance)
    {
        _balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
        Console.WriteLine($"Deposited: {amount}, New Balance: {_balance}");
    }
    public void Withdraw(decimal amount)
    {
        if (_balance >= amount)
        {
            _balance -= amount;
            Console.WriteLine($"Withdrew: {amount}, New Balance: {_balance}");
        }
        else
        {
            Console.WriteLine($"Insufficient funds for withdrawal of {amount}. Current Balance: {_balance}");
        }
    }
}

public class DepositCommand : ICommand
{
    private BankAccount _account;
    private decimal _amount;

    public DepositCommand(BankAccount account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }

    public void Execute()
    {
        _account.Deposit(_amount);
    }
}

public class WithdrawCommand : ICommand
{
    private BankAccount _account;
    private decimal _amount;

    public WithdrawCommand(BankAccount account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }

    public void Execute()
    {
        _account.Withdraw(_amount);
    }
}

public class ATM
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }
    public void ExecuteTransaction()
    {
        _command.Execute();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BankAccount account = new BankAccount(1000);
        ATM atm = new ATM();

        ICommand depositCommand = new DepositCommand(account, 200);
        ICommand withdrawCommand = new WithdrawCommand(account, 150);

        atm.SetCommand(depositCommand);
        atm.ExecuteTransaction(); // Deposited: 200, New Balance: 1200

        atm.SetCommand(withdrawCommand);
        atm.ExecuteTransaction(); // Withdrew: 150, New Balance: 1050

    }
}

// 2. Chain of Responsibility Pattern → Avoids coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects and pass the request along the chain until an object handles it.


public abstract class LeaveApprover
{
    private LeaveApprover _nextApprover;

    public LeaveApprover(LeaveApprover next)
    {
        _nextApprover = nextApprover;
    }

    public abstract void ApproveLeave(int days);

}

// team lead
public class TeamLead : LeaveApprover
{
    

    public override void ApproveLeave(int days)
    {
        if (days <= 2)
        {
            Console.WriteLine("Team Lead approved leave for " + days + " days.");
        }
        else if (_nextApprover != null)
        {
            _nextApprover.ApproveLeave(days);
        }
    }
}

public class Manager : LeaveApprover
{


    public override void ApproveLeave(int days)
    {
        if (days <= 7)
        {
            Console.WriteLine("Manager approved leave for " + days + " days.");
        }
        else if (_nextApprover != null)
        {
            _nextApprover.ApproveLeave(days);
        }
    }
}

public class Director : LeaveApprover
{
    public override void ApproveLeave(int days)
    {
        if (days <= 14)
        {
            Console.WriteLine("Director approved leave for " + days + " days.");
        }
        else
        {
            Console.WriteLine("Leave request for " + days + " days requires higher approval.");
        }
    }
}


class Program2
{
    public static void Main(string[] args)
    {
        LeaveApprover director = new Director();
        LeaveApprover manager = new Manager();
        LeaveApprover teamLead = new TeamLead();

        teamLead.SetNextApprover(manager);
        manager.SetNextApprover(director);

        teamLead.ApproveLeave(1);  // Team Lead approved leave for 1 days.
        teamLead.ApproveLeave(5);  // Manager approved leave for 5 days.
        teamLead.ApproveLeave(10); // Director approved leave for 10 days.
        teamLead.ApproveLeave(20); // Leave request for 20 days requires higher approval.
    }
}