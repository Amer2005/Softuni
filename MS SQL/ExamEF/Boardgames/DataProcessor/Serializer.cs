namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Boardgames.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Serializer
    {
        private static XmlHelper xmlHelper;

        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            xmlHelper = new XmlHelper();

            var creators = context
                .Creators
                .AsNoTracking()
                .Include(c => c.Boardgames)
                .ToArray()
                .Where(c => c.Boardgames.Any())
                .Select(c => new ExportCreatorDto()
                {
                    CreatorName = $"{c.FirstName} {c.LastName}",
                    BoardgamesCount = c.Boardgames.Count(),
                    Boardgames = c.Boardgames.Select(b => new ExportBoardgameDto()
                    {
                        BoardgameName = b.Name,
                        BoardgameYearPublished = b.YearPublished,
                    })
                    .OrderBy(b => b.BoardgameName)
                    .ToArray()
                })
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.CreatorName)
                .ToArray();


            return xmlHelper.Serialize(creators, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var seller = context
                .Sellers
                .AsNoTracking()
                .Include(s => s.BoardgamesSellers)
                .ThenInclude(bs => bs.Boardgame)
                .ToArray()
                .Where(s => s.BoardgamesSellers
                            .Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s
                        .BoardgamesSellers
                        .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
                        .Select(bs => bs.Boardgame)
                        .Select(b => new
                        {
                            Name = b.Name,
                            Rating = b.Rating,
                            Mechanics = b.Mechanics,
                            Category = b.CategoryType.ToString()
                        })
                        .OrderByDescending(b => b.Rating)
                        .ThenBy(b => b.Name)
                        .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(seller, Formatting.Indented);
        }
    }
}