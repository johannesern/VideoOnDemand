
namespace VOD.Films.Database.Extensions;

public static class VODContextExtensions
{
	public static async Task SeedMembershipData(IDbService service)
	{
		//var description = " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus imperdiet vulputate libero, ac lacinia turpis rhoncus sed. Maecenas maximus massa accumsan lectus convallis molestie. Praesent tincidunt sed tellus a rutrum. Maecenas placerat lectus sed nisl aliquet aliquam. Nulla sed consectetur enim. Donec a facilisis eros. Aliquam ut felis at risus finibus vulputate. Donec ac enim lectus. Sed lobortis viverra arcu, sed rhoncus leo finibus eget. Sed eu porta sem. Curabitur nec mattis sem.\r\n\r\nDuis eget odio felis. Proin enim ex, tempus vel urna et, facilisis posuere orci. Mauris sit amet nulla et enim euismod eleifend. Phasellus ultrices, turpis sed imperdiet ullamcorper, sem est sollicitudin justo, ut volutpat ex leo pellentesque neque. Sed egestas, dolor a dignissim porttitor, eros leo pellentesque risus, in dictum tellus nibh a sem. Suspendisse aliquam, erat vel placerat aliquet, lectus sem lobortis felis, a vestibulum est ipsum ac felis. Suspendisse ut sapien in sapien blandit pretium ac quis metus. Nunc sem magna, vulputate vel massa id, dictum efficitur lectus.\r\n\r\nNullam et justo rhoncus, porttitor augue non, maximus nibh. Quisque nec aliquam libero. Pellentesque fermentum mollis sem a placerat. Morbi vulputate risus felis. Nunc porttitor tortor sed dui dictum efficitur. Morbi consectetur et ex vel vehicula. In egestas tristique tincidunt. Aliquam tristique vehicula nisi, nec euismod nunc efficitur et. Vestibulum consectetur elit sed elit sagittis, ac efficitur magna mollis. Ut eu turpis est. Suspendisse mollis dolor vel nibh tincidunt pretium. Nunc bibendum vitae erat eu luctus. Morbi eget diam vel massa pellentesque placerat eu non tellus. ";

		try
		{
			//	#region Directors
			//	await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
			//	{
			//		Name = "Steven Spielberg"
			//	});
			//	await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
			//	{
			//		Name = "Peter Jackson"
			//	});

			//	await service.SaveChangesAsync();
			//	#endregion

			//	#region Genre
			//	await service.AddAsync<Genre, GenreDTO>(new GenreDTO
			//	{
			//		Name = "Action"
			//	});
			//	await service.AddAsync<Genre, GenreDTO>(new GenreDTO
			//	{
			//		Name = "Sci-Fi"
			//	});
			//	await service.AddAsync<Genre, GenreDTO>(new GenreDTO
			//	{
			//		Name = "Thriller"
			//	});
			//	await service.AddAsync<Genre, GenreDTO>(new GenreDTO
			//	{
			//		Name = "Romance"
			//	});
			//	await service.AddAsync<Genre, GenreDTO>(new GenreDTO
			//	{
			//		Name = "History"
			//	});
			//	await service.AddAsync<Genre, GenreDTO>(new GenreDTO
			//	{
			//		Name = "Documentary"
			//	});

			//	await service.SaveChangesAsync();
			//	#endregion

			//	#region Films
			//	await service.AddAsync<Film, FilmDTO>(new FilmDTO
			//	{
			//		Title = "Jurassic Park",
			//		DirectorId = 1,
			//		Released = new DateTime(1993, 06, 11),
			//		ThumbnailURL = "/content/jurassic_park1.jpg",
			//		Description = description.Substring(10, 40),
			//		FilmUrl = "https://www.imdb.com/video/vi177055257/?playlistId=tt0107290&ref_=tt_pr_ov_vi",
			//		Free = true
			//	});

			//	await service.AddAsync<Film, FilmDTO>(new FilmDTO
			//	{
			//		Title = "The Lost World: Jurassic Park",
			//		DirectorId = 1,
			//		Released = new DateTime(1997, 01, 01),
			//		ThumbnailURL = "/content/jurassic_park1.jpg",
			//		Description = description.Substring(10, 40),
			//		FilmUrl = "https://www.imdb.com/video/vi1839120153/?playlistId=tt0119567&ref_=tt_pr_ov_vi",
			//		Free = true
			//	});

			//	await service.AddAsync<Film, FilmDTO>(new FilmDTO
			//	{
			//		Title = "The Lord of the Rings: Fellowship of the Ring",
			//		DirectorId = 2,
			//		Released = new DateTime(2001, 01, 01),
			//		ThumbnailURL = "...",
			//		Description = description.Substring(10, 40),
			//		FilmUrl = "https://www.imdb.com/video/vi684573465/?playlistId=tt0120737&ref_=tt_ov_vi",
			//		Free = true
			//	});
			//	await service.AddAsync<Film, FilmDTO>(new FilmDTO
			//	{
			//		Title = "The Lord of the Rings: The Two Towers",
			//		DirectorId = 2,
			//		Released = new DateTime(2002, 01, 01),
			//		ThumbnailURL = "...",
			//		Description = description.Substring(10, 40),
			//		FilmUrl = "https://www.imdb.com/video/vi701350681/?playlistId=tt0167261&ref_=tt_pr_ov_vi",
			//		Free = true
			//	});
			//	await service.AddAsync<Film, FilmDTO>(new FilmDTO
			//	{
			//		Title = "Jurassic Park III",
			//		DirectorId = 1,
			//		Released = new DateTime(2001, 01, 01),
			//		ThumbnailURL = "/content/jurassic_park3.jpg",
			//		Description = description.Substring(10, 40),
			//		FilmUrl = "https://youtu.be/gjIaV6CU0wA",
			//		Free = true
			//	});
			//	await service.AddAsync<Film, FilmDTO>(new FilmDTO
			//	{
			//		Title = "The Lord of the Rings: The Return of the King",
			//		DirectorId = 1,
			//		Released = new DateTime(2003, 01, 01),
			//		ThumbnailURL = "/content/lotr3.jpg",
			//		Description = description.Substring(10, 40),
			//		FilmUrl = "https://www.imdb.com/video/vi718127897/?playlistId=tt0167260&ref_=tt_pr_ov_vi",
			//		Free = false
			//	});

			//	await service.SaveChangesAsync();
			//	#endregion

			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 1,
			//		GenreId = 1
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 1,
			//		GenreId = 2
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 1,
			//		GenreId = 3
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 2,
			//		GenreId = 1
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 2,
			//		GenreId = 2
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 2,
			//		GenreId = 3
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 3,
			//		GenreId = 1
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 3,
			//		GenreId = 2
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 4,
			//		GenreId = 1
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 4,
			//		GenreId = 2
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 5,
			//		GenreId = 1
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 5,
			//		GenreId = 2
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 5,
			//		GenreId = 6
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 1,
			//		GenreId = 6
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 2,
			//		GenreId = 6
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 6,
			//		GenreId = 1
			//	});
			//	await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
			//	{
			//		FilmId = 6,
			//		GenreId = 2
			//	});

			//	await service.SaveChangesAsync();

			//	await service.AddReferenceAsync<SimilarFilm, SimilarFilmsCreateDTO>(new SimilarFilmsCreateDTO
			//	{
			//		FilmId = 1,
			//		SimilarFilmId = 2
			//	});
			//	await service.AddReferenceAsync<SimilarFilm, SimilarFilmsCreateDTO>(new SimilarFilmsCreateDTO
			//	{
			//		FilmId = 1,
			//		SimilarFilmId = 5
			//	});
			//	await service.AddReferenceAsync<SimilarFilm, SimilarFilmsCreateDTO>(new SimilarFilmsCreateDTO
			//	{
			//		FilmId = 2,
			//		SimilarFilmId = 1
			//	});
			//	await service.AddReferenceAsync<SimilarFilm, SimilarFilmsCreateDTO>(new SimilarFilmsCreateDTO
			//	{
			//		FilmId = 2,
			//		SimilarFilmId = 5
			//	});
			//	await service.AddReferenceAsync<SimilarFilm, SimilarFilmsCreateDTO>(new SimilarFilmsCreateDTO
			//	{
			//		FilmId = 3,
			//		SimilarFilmId = 4
			//	});
			//	await service.AddReferenceAsync<SimilarFilm, SimilarFilmsCreateDTO>(new SimilarFilmsCreateDTO
			//	{
			//		FilmId = 3,
			//		SimilarFilmId = 6
			//	});
			//	await service.AddReferenceAsync<SimilarFilm, SimilarFilmsCreateDTO>(new SimilarFilmsCreateDTO
			//	{
			//		FilmId = 4,
			//		SimilarFilmId = 3
			//	});
			//	await service.AddReferenceAsync<SimilarFilm, SimilarFilmsCreateDTO>(new SimilarFilmsCreateDTO
			//	{
			//		FilmId = 4,
			//		SimilarFilmId = 6
			//	});
			//	await service.AddReferenceAsync<SimilarFilm, SimilarFilmsCreateDTO>(new SimilarFilmsCreateDTO
			//	{
			//		FilmId = 5,
			//		SimilarFilmId = 1
			//	});
			//	await service.AddReferenceAsync<SimilarFilm, SimilarFilmsCreateDTO>(new SimilarFilmsCreateDTO
			//	{
			//		FilmId = 5,
			//		SimilarFilmId = 2
			//	});
			//	await service.AddReferenceAsync<SimilarFilm, SimilarFilmsCreateDTO>(new SimilarFilmsCreateDTO
			//	{
			//		FilmId = 6,
			//		SimilarFilmId = 3
			//	});
			//	await service.AddReferenceAsync<SimilarFilm, SimilarFilmsCreateDTO>(new SimilarFilmsCreateDTO
			//	{
			//		FilmId = 6,
			//		SimilarFilmId = 4
			//	});

			//	await service.SaveChangesAsync();

		}
		catch (Exception ex)
		{

		}
	}
}

