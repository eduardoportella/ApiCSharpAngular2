namespace ApiCSharpAngular.Routes;
using ApiCSharpAngular.Models;

public static class PeopleRoutes{
    public static List<Person> People = new() { 
        new (id:Guid.NewGuid(), "Art"),
        new (id:Guid.NewGuid(), "KsCerato"),
        new (id:Guid.NewGuid(), "Fallen")
    };  

    public static void PeopleRoutesMap(this WebApplication app){
        app.MapGet("/people", () => {
            return new {People};
        });

        // app.MapGet("people/{name}", (string name) => {
        //     return People.Find(person => person.Name == name);
        // });

        app.MapGet("/people/{name}", (string name) => People.Find(person => person.Name == name));

        app.MapPost("/person", (HttpContext request, Person person) => {
            // if (person.Name != "Eduardo"){
            //     return Results.BadRequest(new {message = "Name is Not Eduardo"});
            // } 

            var name = request.Request.Query["name"];
            
            People.Add(person);
            return Results.Ok(person);
        });

        app.MapPut("/person/{id:guid}", (Guid id, Person person) => {
            var finded = People.Find(person => person.Id == id);

            if (finded == null){
                return Results.NotFound();
            }

            finded.Name = person.Name;

            return Results.Ok();

        });

        // app.MapDelete("/person/{id:guid}", (Guid id, Person person) => {
        //     var personData = People.Find(person => person.Id == id);
            
        //     if (personData == null){
        //         return Results.NotFound();
        //     }

        //     // People.Remove(personData);

        //     return Results.Ok();

        // });
            
    }
}