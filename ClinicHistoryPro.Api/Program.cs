using ClinicHistoryPro.Api.Middleware;
using ClinicHistoryPro.Application.Cqrs.Form;
using ClinicHistoryPro.Application.Services;
using ClinicHistoryPro.Application.Services.Interfaces;
using ClinicHistoryPro.Infraestructure.Adapters;
using ClinicHistoryPro.Infraestructure.Persistence.Configurations;
using ClinicHistoryPro.Infraestructure.Ports;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(opt => opt.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Context
//builder.Services.AddDbContext<PayrollContext>();
builder.Services.AddDbContext<ClinicHistoryContext>();

//Add MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(
        Assembly.GetExecutingAssembly(), typeof(GetOneFormRequest).Assembly
    )
);

//Add Inversion dependency
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IDynamicRepository<>), typeof(DynamicRepository<>));
builder.Services.AddTransient<IFormAppService, FormAppService>();
builder.Services.AddTransient<IDocumentTypeAppService, DocumentTypeAppService>();
builder.Services.AddTransient<IMenuItemAppService, MenuItemAppService>();
builder.Services.AddTransient<IGenderAppService, GenderAppService>();
builder.Services.AddTransient<ILocalizationAppService, LocalizationAppService>();
builder.Services.AddTransient<IPatientAppService, PatientAppService>();
builder.Services.AddTransient<IAdministratorAppService, AdministratorAppService>();

//Add Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();
app.MapControllers();
app.Run();
