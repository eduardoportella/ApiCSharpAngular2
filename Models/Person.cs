namespace ApiCSharpAngular.Models;

public class Person {
    public Guid Id {get; set;}
    public string Name {get; set;}

    public Person(Guid id, string name){
        Id = id;
        Name = name;
    }
}