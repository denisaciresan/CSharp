
public class BankAccount
{
    public readonly int _id;
    public readonly int _pin;
    public double _sum_lei;
    public double _sum_euro;
    public double _sum_dollar;

    public BankAccount(int id, int pin, double sum_lei, double sum_euro, double sum_dolar)
    {
        _id = id;
        _pin = pin;
        _sum_lei = sum_lei;
        _sum_euro = sum_euro;
        _sum_dollar = sum_dolar;
    }
}
