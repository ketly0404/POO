namespace POO;

class Program
{
    static void Main(string[] args)
    {
   
        Animal[] animais = 
        [
            new Cachorro("Pipoca", 9),
        
            new Gato("Pirulito",  2 ),
        
            new Manuzica("Manu", 16)
        ];

        foreach (Animal animalAtual in animais)
        {
            
            animalAtual.Comer();
            animalAtual.FazerBarulho();
            
        }
    }
}