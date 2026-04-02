WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();
app.Urls.Add("http://*:5023");
app.Urls.Add("http://localhost:5023");

List<Teacher> teachers = [
    new()
    {
        Name = "Micke",
        Age = 67,
        IsSigma = true
    },
    new()
    {
        Name = "Martin",
        Age = 9001,
        IsSigma = false
    },
    new()
    {
        Name = "Liv",
        Age = 101010101,
        IsSigma = true
    }
];

app.MapGet("/", SayHello);
app.MapGet("/micke", GetSigmanMicke);
app.MapGet("/teacher/{n}", getTeacher);
app.MapGet("/teacher/", ListTeachers);

app.MapPost("/teacher/", AddTeacher);

app.Run(); //intern loop som kollar https request

static string SayHello() => "Hej på er sigmor!";

void AddTeacher(Teacher t) =>teachers.Add(t);

List<Teacher> ListTeachers() => teachers;

IResult getTeacher(int n)
{
    if (n < 0 || n >= teachers.Count)
    {
        return Results.NotFound();
    }

    return Results.Ok(teachers[n]);
}

static Teacher GetSigmanMicke()
{
    Teacher micke = new()
    {
        Name = "Micke",
        Age = 67,
        IsSigma = true
    };

    return micke;
}