namespace POO;

public class Manuzica : Animal
{
    public Manuzica(string nome, int idade) : base(nome, idade)
    {
        
    }
    public override void FazerBarulho()
    {
        Console.WriteLine($"{Nome} fez Maaanuuuuu");       
    } 

}