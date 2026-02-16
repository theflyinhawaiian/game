
using System;

public class BankAccount
{
    private int Money { get; set; }

    public BankAccount()
    {
        Money = 0;
    }

    public void DepositMoney(int depositedmoney)
    {
        if (depositedmoney <= 0)
        {
            Console.WriteLine("Please try again later with a valid number");
            return;
        }

        Money += depositedmoney;
        Console.WriteLine(Money);
    }

    public void DepositMoney(string depositedMoney)
    {
        var converted = Int32.Parse(depositedMoney);
        DepositMoney(converted);
    }

    public void WithdrawMoney(int withdrawnMoney)
    {
        if (withdrawnMoney > Money)
        {
            Console.WriteLine("error, you cannot withdraw this much money. Your current balance is " + Money);
            return;
        }
        if (withdrawnMoney <= 0)
        {
            Console.WriteLine("Please try again later with a valid number");
            return;
        }


        Money -= withdrawnMoney;
        Console.WriteLine(Money);
    }





}
public class Program
{
    public static void Main(string[] args)
    {
        var myBankAccount = new BankAccount();
        myBankAccount.DepositMoney("50");
        myBankAccount.WithdrawMoney(5);


    }
}