using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Logging.ClearProviders();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

var sampleTodos = new Todo[] {
    new(1, "Walk the dog"),
    new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
    new(4, "Clean the bathroom"),
    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
};

var todosApi = app.MapGroup("/todos");
//todosApi.MapGet("/", () => sampleTodos);

todosApi.MapGet("/", async () =>
{

    Console.WriteLine("starting the app");

    using (var ctx = new EFCoreAotBenchmarkContext())
    {
        Console.WriteLine("accessing model");

        var model = ctx.Model;

        Console.WriteLine("On model creating ran? - " + EFCoreAotBenchmarkContext.OnModelCreatingRan);

        Console.WriteLine("accessing model - done");

        Console.WriteLine("running queries");

        var result0 = await ctx.Entities0.Where(x => x.Name1.Contains("e")).OrderBy(x => x.Id).Take(10).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
        var result1 = await ctx.Entities1.Where(x => x.Name2.Contains("e")).OrderBy(x => x.Id).Take(11).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
        var result2 = await ctx.Entities2.Where(x => x.Name3.Contains("e")).OrderBy(x => x.Id).Take(12).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
        var result3 = await ctx.Entities3.Where(x => x.Name4.Contains("e")).OrderBy(x => x.Id).Take(13).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
        var result4 = await ctx.Entities4.Where(x => x.Name5.Contains("e")).OrderBy(x => x.Id).Take(14).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
        var result5 = await ctx.Entities5.Where(x => x.Number1 > 5).OrderBy(x => x.Id).Take(15).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
        var result6 = await ctx.Entities6.Where(x => x.Number2 < 5).OrderBy(x => x.Id).Take(3).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
        var result7 = await ctx.Entities7.Where(x => x.Number3 == 7).OrderBy(x => x.Id).Take(17).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
        var result8 = await ctx.Entities8.Where(x => !x.Name1.Contains("e")).OrderBy(x => x.Id).Take(18).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();
        var result9 = await ctx.Entities9.Where(x => !x.Name1.Contains("a")).OrderBy(x => x.Id).Take(4).Select(x => new { x.Id, x.Name1, x.Name2, x.Name3, x.Name4, x.Name5, x.Number1, x.Number2, x.Number3, x.Enum1, x.Enum2, x.Date1, x.Date2, x.Date3, x.PrimAr1, x.PrimAr2, x.Owned }).AsNoTracking().ToListAsync();

        Console.WriteLine(result0.Count);

        Console.WriteLine("result1 name1: " + result1[0].Name1);

        Console.WriteLine("running queries - done");
    }

    Console.WriteLine("finished running the app");

});

// Keeping because it is in the template but not actually benchmarked.
todosApi.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.Lifetime.ApplicationStarted.Register(() => Console.WriteLine("Application started. Press Ctrl+C to shut down."));

app.Run();

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}


public class MyEntity1
{
    public int Id { get; set; }
    public string Name1 { get; set; } = null!;
    public string Name2 { get; set; } = null!;
    public string Name3 { get; set; } = null!;
    public string Name4 { get; set; } = null!;
    public string Name5 { get; set; } = null!;

    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public int Number3 { get; set; }

    public DateTime Date1 { get; set; }
    public DateTime Date2 { get; set; }
    public DateTime Date3 { get; set; }
    public MyEnum1 Enum1 { get; set; }
    public MyEnum1 Enum2 { get; set; }

    public int[] PrimAr1 { get; set; } = null!;
    public string[] PrimAr2 { get; set; } = null!;

    public List<MyRoot1> Owned { get; set; } = null!;
}

public enum MyEnum1
{
    Foo,
    Bar,
    Baz,
}

public class MyRoot1
{
    public string Prop1 { get; set; } = null!;
    public string Prop2 { get; set; } = null!;
    public string Prop3 { get; set; } = null!;
    public string Prop4 { get; set; } = null!;
    public string Prop5 { get; set; } = null!;
}

public class MyEntity2
{
    public int Id { get; set; }
    public string Name1 { get; set; } = null!;
    public string Name2 { get; set; } = null!;
    public string Name3 { get; set; } = null!;
    public string Name4 { get; set; } = null!;
    public string Name5 { get; set; } = null!;

    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public int Number3 { get; set; }

    public DateTime Date1 { get; set; }
    public DateTime Date2 { get; set; }
    public DateTime Date3 { get; set; }
    public MyEnum2 Enum1 { get; set; }
    public MyEnum2 Enum2 { get; set; }

    public int[] PrimAr1 { get; set; } = null!;
    public string[] PrimAr2 { get; set; } = null!;

    public List<MyRoot2> Owned { get; set; } = null!;
}

public enum MyEnum2
{
    Foo,
    Bar,
    Baz,
}

public class MyRoot2
{
    public string Prop1 { get; set; } = null!;
    public string Prop2 { get; set; } = null!;
    public string Prop3 { get; set; } = null!;
    public string Prop4 { get; set; } = null!;
    public string Prop5 { get; set; } = null!;
}

public class MyEntity3
{
    public int Id { get; set; }
    public string Name1 { get; set; } = null!;
    public string Name2 { get; set; } = null!;
    public string Name3 { get; set; } = null!;
    public string Name4 { get; set; } = null!;
    public string Name5 { get; set; } = null!;

    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public int Number3 { get; set; }

    public DateTime Date1 { get; set; }
    public DateTime Date2 { get; set; }
    public DateTime Date3 { get; set; }
    public MyEnum3 Enum1 { get; set; }
    public MyEnum3 Enum2 { get; set; }

    public int[] PrimAr1 { get; set; } = null!;
    public string[] PrimAr2 { get; set; } = null!;

    public List<MyRoot3> Owned { get; set; } = null!;
}

public enum MyEnum3
{
    Foo,
    Bar,
    Baz,
}

public class MyRoot3
{
    public string Prop1 { get; set; } = null!;
    public string Prop2 { get; set; } = null!;
    public string Prop3 { get; set; } = null!;
    public string Prop4 { get; set; } = null!;
    public string Prop5 { get; set; } = null!;
}

public class MyEntity4
{
    public int Id { get; set; }
    public string Name1 { get; set; } = null!;
    public string Name2 { get; set; } = null!;
    public string Name3 { get; set; } = null!;
    public string Name4 { get; set; } = null!;
    public string Name5 { get; set; } = null!;

    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public int Number3 { get; set; }

    public DateTime Date1 { get; set; }
    public DateTime Date2 { get; set; }
    public DateTime Date3 { get; set; }
    public MyEnum4 Enum1 { get; set; }
    public MyEnum4 Enum2 { get; set; }

    public int[] PrimAr1 { get; set; } = null!;
    public string[] PrimAr2 { get; set; } = null!;

    public List<MyRoot4> Owned { get; set; } = null!;
}

public enum MyEnum4
{
    Foo,
    Bar,
    Baz,
}

public class MyRoot4
{
    public string Prop1 { get; set; } = null!;
    public string Prop2 { get; set; } = null!;
    public string Prop3 { get; set; } = null!;
    public string Prop4 { get; set; } = null!;
    public string Prop5 { get; set; } = null!;
}

public class MyEntity5
{
    public int Id { get; set; }
    public string Name1 { get; set; } = null!;
    public string Name2 { get; set; } = null!;
    public string Name3 { get; set; } = null!;
    public string Name4 { get; set; } = null!;
    public string Name5 { get; set; } = null!;

    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public int Number3 { get; set; }

    public DateTime Date1 { get; set; }
    public DateTime Date2 { get; set; }
    public DateTime Date3 { get; set; }
    public MyEnum5 Enum1 { get; set; }
    public MyEnum5 Enum2 { get; set; }

    public int[] PrimAr1 { get; set; } = null!;
    public string[] PrimAr2 { get; set; } = null!;

    public List<MyRoot5> Owned { get; set; } = null!;
}

public enum MyEnum5
{
    Foo,
    Bar,
    Baz,
}

public class MyRoot5
{
    public string Prop1 { get; set; } = null!;
    public string Prop2 { get; set; } = null!;
    public string Prop3 { get; set; } = null!;
    public string Prop4 { get; set; } = null!;
    public string Prop5 { get; set; } = null!;
}

public class MyEntity6
{
    public int Id { get; set; }
    public string Name1 { get; set; } = null!;
    public string Name2 { get; set; } = null!;
    public string Name3 { get; set; } = null!;
    public string Name4 { get; set; } = null!;
    public string Name5 { get; set; } = null!;

    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public int Number3 { get; set; }

    public DateTime Date1 { get; set; }
    public DateTime Date2 { get; set; }
    public DateTime Date3 { get; set; }
    public MyEnum6 Enum1 { get; set; }
    public MyEnum6 Enum2 { get; set; }

    public int[] PrimAr1 { get; set; } = null!;
    public string[] PrimAr2 { get; set; } = null!;

    public List<MyRoot6> Owned { get; set; } = null!;
}

public enum MyEnum6
{
    Foo,
    Bar,
    Baz,
}

public class MyRoot6
{
    public string Prop1 { get; set; } = null!;
    public string Prop2 { get; set; } = null!;
    public string Prop3 { get; set; } = null!;
    public string Prop4 { get; set; } = null!;
    public string Prop5 { get; set; } = null!;
}

public class MyEntity7
{
    public int Id { get; set; }
    public string Name1 { get; set; } = null!;
    public string Name2 { get; set; } = null!;
    public string Name3 { get; set; } = null!;
    public string Name4 { get; set; } = null!;
    public string Name5 { get; set; } = null!;

    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public int Number3 { get; set; }

    public DateTime Date1 { get; set; }
    public DateTime Date2 { get; set; }
    public DateTime Date3 { get; set; }
    public MyEnum7 Enum1 { get; set; }
    public MyEnum7 Enum2 { get; set; }

    public int[] PrimAr1 { get; set; } = null!;
    public string[] PrimAr2 { get; set; } = null!;

    public List<MyRoot7> Owned { get; set; } = null!;
}

public enum MyEnum7
{
    Foo,
    Bar,
    Baz,
}

public class MyRoot7
{
    public string Prop1 { get; set; } = null!;
    public string Prop2 { get; set; } = null!;
    public string Prop3 { get; set; } = null!;
    public string Prop4 { get; set; } = null!;
    public string Prop5 { get; set; } = null!;
}

public class MyEntity8
{
    public int Id { get; set; }
    public string Name1 { get; set; } = null!;
    public string Name2 { get; set; } = null!;
    public string Name3 { get; set; } = null!;
    public string Name4 { get; set; } = null!;
    public string Name5 { get; set; } = null!;

    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public int Number3 { get; set; }

    public DateTime Date1 { get; set; }
    public DateTime Date2 { get; set; }
    public DateTime Date3 { get; set; }
    public MyEnum8 Enum1 { get; set; }
    public MyEnum8 Enum2 { get; set; }

    public int[] PrimAr1 { get; set; } = null!;
    public string[] PrimAr2 { get; set; } = null!;

    public List<MyRoot8> Owned { get; set; } = null!;
}

public enum MyEnum8
{
    Foo,
    Bar,
    Baz,
}

public class MyRoot8
{
    public string Prop1 { get; set; } = null!;
    public string Prop2 { get; set; } = null!;
    public string Prop3 { get; set; } = null!;
    public string Prop4 { get; set; } = null!;
    public string Prop5 { get; set; } = null!;
}

public class MyEntity9
{
    public int Id { get; set; }
    public string Name1 { get; set; } = null!;
    public string Name2 { get; set; } = null!;
    public string Name3 { get; set; } = null!;
    public string Name4 { get; set; } = null!;
    public string Name5 { get; set; } = null!;

    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public int Number3 { get; set; }

    public DateTime Date1 { get; set; }
    public DateTime Date2 { get; set; }
    public DateTime Date3 { get; set; }
    public MyEnum9 Enum1 { get; set; }
    public MyEnum9 Enum2 { get; set; }

    public int[] PrimAr1 { get; set; } = null!;
    public string[] PrimAr2 { get; set; } = null!;

    public List<MyRoot9> Owned { get; set; } = null!;
}

public enum MyEnum9
{
    Foo,
    Bar,
    Baz,
}

public class MyRoot9
{
    public string Prop1 { get; set; } = null!;
    public string Prop2 { get; set; } = null!;
    public string Prop3 { get; set; } = null!;
    public string Prop4 { get; set; } = null!;
    public string Prop5 { get; set; } = null!;
}

public class MyEntity0
{
    public int Id { get; set; }
    public string Name1 { get; set; } = null!;
    public string Name2 { get; set; } = null!;
    public string Name3 { get; set; } = null!;
    public string Name4 { get; set; } = null!;
    public string Name5 { get; set; } = null!;

    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public int Number3 { get; set; }

    public DateTime Date1 { get; set; }
    public DateTime Date2 { get; set; }
    public DateTime Date3 { get; set; }
    public MyEnum0 Enum1 { get; set; }
    public MyEnum0 Enum2 { get; set; }

    public int[] PrimAr1 { get; set; } = null!;
    public string[] PrimAr2 { get; set; } = null!;

    public List<MyRoot0> Owned { get; set; } = null!;
}

public enum MyEnum0
{
    Foo,
    Bar,
    Baz,
}

public class MyRoot0
{
    public string Prop1 { get; set; } = null!;
    public string Prop2 { get; set; } = null!;
    public string Prop3 { get; set; } = null!;
    public string Prop4 { get; set; } = null!;
    public string Prop5 { get; set; } = null!;
}

public class EFCoreAotBenchmarkContext : DbContext
{
    public static bool OnModelCreatingRan { get; set; } = false;

    public DbSet<MyEntity0> Entities0 { get; set; } = null!;
    public DbSet<MyEntity1> Entities1 { get; set; } = null!;
    public DbSet<MyEntity2> Entities2 { get; set; } = null!;
    public DbSet<MyEntity3> Entities3 { get; set; } = null!;
    public DbSet<MyEntity4> Entities4 { get; set; } = null!;
    public DbSet<MyEntity5> Entities5 { get; set; } = null!;
    public DbSet<MyEntity6> Entities6 { get; set; } = null!;
    public DbSet<MyEntity7> Entities7 { get; set; } = null!;
    public DbSet<MyEntity8> Entities8 { get; set; } = null!;
    public DbSet<MyEntity9> Entities9 { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingRan = true;

        modelBuilder.Entity<MyEntity0>().OwnsMany(x => x.Owned, b => { b.ToJson(); });
        modelBuilder.Entity<MyEntity1>().OwnsMany(x => x.Owned, b => { b.ToJson(); });
        modelBuilder.Entity<MyEntity2>().OwnsMany(x => x.Owned, b => { b.ToJson(); });
        modelBuilder.Entity<MyEntity3>().OwnsMany(x => x.Owned, b => { b.ToJson(); });
        modelBuilder.Entity<MyEntity4>().OwnsMany(x => x.Owned, b => { b.ToJson(); });
        modelBuilder.Entity<MyEntity5>().OwnsMany(x => x.Owned, b => { b.ToJson(); });
        modelBuilder.Entity<MyEntity6>().OwnsMany(x => x.Owned, b => { b.ToJson(); });
        modelBuilder.Entity<MyEntity7>().OwnsMany(x => x.Owned, b => { b.ToJson(); });
        modelBuilder.Entity<MyEntity8>().OwnsMany(x => x.Owned, b => { b.ToJson(); });
        modelBuilder.Entity<MyEntity9>().OwnsMany(x => x.Owned, b => { b.ToJson(); });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=efcoreaotbenchmark.db");
}