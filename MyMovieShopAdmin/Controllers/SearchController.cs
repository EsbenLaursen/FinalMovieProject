using MovieShopDll;
using MovieShopDll.Entities;
using MyMovieShopAdmin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MyMovieShopAdmin.Controllers
{
    public class SearchController : ApplicationController
    {
        // GET: Search
        IManager<Movie> mm = new DllFacade().GetMovieManager();
    
        public ActionResult Index(int? page)
        {
            List<Movie> Moviez = SearchCriteria.Movies;
            int perpage = SearchCriteria.PerPage;

            if (perpage == 0)
            {
                perpage = 6;
            }
            if (!page.HasValue)
            {
                page = 1;
            }
            if (Moviez == null)
            {
                Moviez = mm.Read().ToList();
            }
            //Pager
            Pager pager = new Pager(Moviez.Count, page, perpage);
            SearchIndexViewModel viewModel = new SearchIndexViewModel()
            {
                Movies = Moviez.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList(),
                Pager = pager,
                LastSelectedMoviesPerPage = SearchCriteria.PerPage,
                LastSelectedGenre = SearchCriteria.GenreBy,
                LastSelectedOrderBy = SearchCriteria.OrderByStatic
            };

            return View(viewModel); 
        }


        public ActionResult AdvancedSearch(SearchCriteria search)
        {

           List<Movie> newList = new List<Movie>();
            //foreach (var movie in mm.Read())
            //{
            //    bool matchCriteria = search.MatchesCriteria(search, movie);
            //    if (matchCriteria)
            //    {
            //        newList.Add(movie);
            //    }
            //}


            var itemsPerPage = 0;

            if (search.SearchQuery == null)
            {
                search.SearchQuery = "";
            }
            if (search.OrderBy == null)
            {
                search.OrderBy = "Ascending";
            }
            if (search.Genre == null)
            {
                search.Genre = "All";
            }
            if (search.ItemsPerPage == 0)
            {
                itemsPerPage = 5;
            }
            else
            {
                itemsPerPage = search.ItemsPerPage;
            }






            if (search.Genre != "All") // Genre er valgt
            {
                if (search.SearchQuery == "")
                {
                    if (search.OrderBy == "Ascending")
                    {
                        List<Movie> temp = mm.Read();
                        foreach (var movie in temp)
                        {
                            bool l = false;

                            foreach (var genre in movie.Genres)
                            {
                                
                                if (genre.Name.ToLower().Equals(search.Genre.ToLower()))
                                    {
                                    newList.Add(movie);
                                    l = true;
                                }
                                if (l == true) break;
                                
                            }
                        }
                        newList.OrderBy(x => x.Title);
                        

                    }
                    else
                    {
                      //  newList = mm.Read().Where(x => x.Genre.Name == search.Genre).OrderByDescending(x => x.Title).ToList();
                    }
                }
                else
                {
                    if (search.OrderBy == "Ascending")
                    {
                     //   newList = mm.Read().Where(x => x.Genre.Name == search.Genre).Where(x => x.Title.Contains(search.SearchQuery)).OrderBy(x => x.Title).ToList();
                    }
                    else
                    {
                    //    newList = mm.Read().Where(x => x.Genre.Name == search.Genre).Where(x => x.Title.Contains(search.SearchQuery)).OrderByDescending(x => x.Title).ToList();
                    }
                }
            }
            else
            {
                if (search.SearchQuery == "")
                {
                    if (search.OrderBy == "Ascending")
                    {
                        newList = mm.Read().OrderBy(x => x.Title).ToList();
                    }
                    else
                    {
                        newList = mm.Read().OrderByDescending(x => x.Title).ToList();
                    }
                }
                else
                {
                    if (search.OrderBy == "Ascending")
                    {
                        newList = mm.Read().Where(x => x.Title.Contains(search.SearchQuery)).OrderBy(x => x.Title).ToList();
                    }
                    else
                    {
                        newList = mm.Read().Where(x => x.Title.Contains(search.SearchQuery)).OrderByDescending(x => x.Title).ToList();
                    }
                }
            }
            SearchCriteria.Movies = newList;
            SearchCriteria.PerPage = itemsPerPage;
            SearchCriteria.OrderByStatic = search.OrderBy;
            SearchCriteria.GenreBy = search.Genre;
            return RedirectToAction("Index");
        }

        
    }
}