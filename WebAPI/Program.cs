using BusinessLayer.BLs;
using BusinessLayer.IBLs;
using DataAccessLayer.DALs.Personas;
using DataAccessLayer.IDALs;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

try {

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddDbContext<DBContextCore>();
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    #region Inyeccion de dependencias
    builder.Services.AddTransient<IDAL_Personas, DAL_Personas_EF>();

    builder.Services.AddTransient<IBL_Personas, BL_Personas>();
    #endregion

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment()) {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    UpdateDatabase();

    app.Run();

} catch (Exception ex) {
    Console.WriteLine( "Error:" + ex.Message);
}

static void UpdateDatabase() {
    using (var context = new DataAccessLayer.DBContextCore()) {
        context?.Database.Migrate();
    }
}