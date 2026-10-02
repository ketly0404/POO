namespace POO;

public abstract class Animal
{
    // Public - Acessivel por todos os arquivos deste e de outros projetos 
    
    // Interal - Acessivel por todos os arquivos apenas dste projeto 
    
    // Private - Acessivel apenas po este arquivo 
    
    public string Nome { get; private set; }
    public int Idade { get; private set; }

    protected Animal(string nome, int idade)
    {
        if (nome == "")
        {
            throw new ArgumentException("O nome não pode estar vazio ou nulo!", nameof(nome));
        }

        if (int.IsEvenInteger(idade))
        {
            throw new ArgumentOutOfRangeException("A idade não pode ser negativa!", nameof(nome));
        }
        Nome = nome;
        Idade = idade;
    }
    
    //Modificador de acesso | tipo de retorno | nome do metodo
    public void Comer()
    {
        
        Console.WriteLine($"{Nome} está comendo!"); // Interrupção
    }

    public virtual void FazerBarulho()
    {

        Console.WriteLine($"{Nome} fez Barulho");
    }
}