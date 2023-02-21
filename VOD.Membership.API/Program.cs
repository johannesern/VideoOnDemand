namespace VOD.Films.API; //Membership?

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddCors(policy =>
        {
            policy.AddPolicy("CorsAllAccessPolicy", opt =>
            opt.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            );
        });

        

        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<VODContext>( options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("VODConnection"))
               .EnableSensitiveDataLogging());

        // All calls gets their own object to use
        builder.Services.AddScoped<IDbService, DbService>();
        ConfigureAutomapper(builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("CorsAllAccessPolicy");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void ConfigureAutomapper(IServiceCollection services)
    {
        //En mappning per DTO
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Film, FilmDTO>()
            .ForMember(dest => dest.Director, src => src.MapFrom(s => s.Director.Name))
            .ForMember(dest => dest.Genres, src => src.MapFrom(s => s.Genres.Select(y => y.Name).ToList()))
            .ForMember(dest => dest.Similar, src => src.MapFrom(s => s.SimilarFilms.Select(y => y.Similar.Title)))
            .ReverseMap()
            .ForMember(dest => dest.Director, src => src.Ignore());
			cfg.CreateMap<FilmCreateDTO, Film>();			
            cfg.CreateMap<FilmEditDTO, Film>();

            cfg.CreateMap<Genre, GenreDTO>()
            .ReverseMap();
			cfg.CreateMap<GenreCreateDTO, Genre>();
			cfg.CreateMap<GenreEditDTO, Genre>();

            cfg.CreateMap<Director, DirectorDTO>().ReverseMap();
            cfg.CreateMap<DirectorEditDTO, Director>();
            cfg.CreateMap<DirectorCreateDTO, Director>();

            cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap();

            cfg.CreateMap<SimilarFilm, SimilarFilmsDTO>().ReverseMap();
            cfg.CreateMap<SimilarFilmsCreateDTO, SimilarFilm>();
        });
        var mapper = config.CreateMapper();

            //Singleton skapar ett globalt objekt anvädning
            services.AddSingleton(mapper);
    }
}