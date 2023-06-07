using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Application.Service.SQLServerServices;
using SistemaHospitalar.Domain.IRepositories;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Domain.Repositories;
using SistemaHospitalar.Infra.Data.Context;
using SistemaHospitalar.Web.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Context SQL Server
builder.Services.AddDbContext<SQLServerContext>
    (options => options.UseSqlServer("Server=tcp:prontclinicserverdb.database.windows.net,1433;Initial Catalog=ProntClinicDb;Persist Security Info=False;User ID=1243087@sga.pucminas.br;Password=170599Gug@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication='Active Directory Password';"));

//Service
builder.Services.AddScoped<IConvenioService, ConvenioService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IEspecialidadeMedicaService, EspecialidadeMedicaService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IProntuarioService, ProntuarioService>();
builder.Services.AddScoped<IRecepcionistaService, RecepcionistaService>();

//Repository
builder.Services.AddScoped<IConvenioRepository, ConvenioRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IEspecialidadeMedicaRepository, EspecialidadeMedicaRepository>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IProntuarioRepository, ProntuarioRepository>();
builder.Services.AddScoped<IRecepcionistaRepository, RecepcionistaRepository>();

//Sessao
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISessao, Sessao>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",

    pattern: "{controller=Login}/{action=Create}/{id?}");

app.Run();
