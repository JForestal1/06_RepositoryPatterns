using _06_RepositoryPattern_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_RepositoryPattern_Console
{
    class ProgramUI
    {
        // This is the method that starts the application
        private StreamingContentRepository _contentRepo = new StreamingContentRepository();

        public void Run()
        {
            Menu();
            //* meaningless change to test git push
            //* another meaningless change for git
        }

        //Menu

        private void Menu()
        {
            // display the options
            // take user choice
            // evaluate input
            // take action

            bool active = true;

            while (active)
            {


                Console.WriteLine("Select A Menu Option:\n" +
                    "S - Seed the list for testing\n" +
                    "A - Add a Content Item\n" +
                    "T - View a Content Item by Title\n" +
                    "V - View All Content Items\n" +
                    "D - Delete a Content Item\n" +
                    "U - Update a Content Item\n" +
                    "X - Exit");


                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "s":
                        {
                            SeedContentList();
                            break;
                        }
                    case "a":
                        {
                            CreateNewContent();
                            break;
                        }
                    case "t":
                        {
                            ViewContentByTitle();
                            break;
                        }
                    case "v":
                        {
                            ViewAllContent();
                            break;
                        }
                    case "d":
                        {
                            DeleteContent();
                            break;
                        }
                    case "u":
                        {
                            UpdateContent();
                            break;
                        }
                    case "x":
                        {
                            Console.WriteLine("Thanks for coming by");
                            Console.Beep(1000,500);
                            active = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter a valid choice!");
                            break;
                        }

                }

                if (active)
                {
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
             
        private void CreateNewContent()
        {
            Console.Clear();
            StreamingContent newContent = new StreamingContent();
                        
            // Get title
            Console.WriteLine("Enter a Title");
            newContent.Title = Console.ReadLine();
            
            // Get Description
                        Console.WriteLine("Enter a Description");
            newContent.Description = Console.ReadLine();
            
            // Get Maturity
                        Console.WriteLine("Enter a Maturity Rating");
            newContent.Title = Console.ReadLine();
           
            // Get Star
                        Console.WriteLine("Enter a Star Rating");
            string starsAsString = Console.ReadLine();
            newContent.StarRating = double.Parse(starsAsString);
            
            
            // Get Family friedly 
            Console.WriteLine("Is this Family Friendly (Y/N)");
            string isFamilyFriendlyAsString =  Console.ReadLine().ToLower();
            if(isFamilyFriendlyAsString == "y")
            {
                newContent.IsFamilyFriendly = true;
            }
            else
            {
                newContent.IsFamilyFriendly = false;
            }

            Console.WriteLine("Enter the Genre type: \n" +
                "1. SciFi\n" +
                "2. RomCom\n" +
                "3. Indie\n" +
                "4. Bromance\n" +
                "5. Action\n" +
                "6. SuperHero");
            
            string genreAsString = Console.ReadLine().ToLower();
            int genreAsInt = int.Parse(genreAsString);
            newContent.TypeOfGenre = (GenreType) genreAsInt;

            _contentRepo.AddContentToList(newContent);
        }
        private void ViewContentByTitle()
        {
            Console.WriteLine("Enter Title to display:");
            string contentTitle = Console.ReadLine();
            StreamingContent content = _contentRepo.GetContentByTitle(contentTitle);
            if (content == null)
            {
                Console.WriteLine("No content found!");
            }
            else
            {
                Console.WriteLine($"Title: {content.Title},\n" +
                        $" Description: {content.Description}\n" +
                        $" Maturity Rating: {content.MaturityRating}\n" +
                        $" Star Rating: {content.StarRating}\n" +
                        $" Family Friendly?: {content.IsFamilyFriendly}\n" +
                        $" Genre:  {content.TypeOfGenre}");
            }
        }
        private void ViewAllContent()
        {
            Console.Clear(); 
            List<StreamingContent> listOfContent = _contentRepo.GetContentList();
            foreach (StreamingContent content in listOfContent)
            {
                Console.WriteLine($"Title: {content.Title},\n" +
                    $" Description: {content.Description}\n\n");
                   }
        
        }
        private void DeleteContent()
        {
            StreamingContent editedContent = new StreamingContent();

            Console.Clear();
            Console.WriteLine("Enter Title to delete:");
            string deleteContentTitle = Console.ReadLine();

            bool didDelete = _contentRepo.RemoveContentFromList(deleteContentTitle);
            if (didDelete)
            {
                Console.WriteLine("Update Successful");
            }
            else
            {
                Console.WriteLine("Opps");
            }
        }


        private void UpdateContent()
        {
            StreamingContent editedContent = new StreamingContent();

            Console.Clear();
            Console.WriteLine("Enter Title to edit:");
            string oldContentTitle = Console.ReadLine();

            // Get new title
            Console.WriteLine("Enter a new Title");
            editedContent.Title = Console.ReadLine();

            // Get new Description
            Console.WriteLine("Enter a new Description");
            editedContent.Description = Console.ReadLine();

            // Get new Maturity
            Console.WriteLine("Enter a new Maturity Rating");
            editedContent.MaturityRating = Console.ReadLine();

            // Get new Star
            Console.WriteLine("Enter a new Star Rating");
            string starsAsString = Console.ReadLine();
            editedContent.StarRating = double.Parse(starsAsString);

            //get new family friendly 
            Console.WriteLine("Edit Family Friendly (Y/N)");
            string isFamilyFriendlyAsString = Console.ReadLine().ToLower();
            if (isFamilyFriendlyAsString == "y")
            {
                editedContent.IsFamilyFriendly = true;
            }
            else
            {
                editedContent.IsFamilyFriendly = false;
            }
            Console.WriteLine("Enter a new Genre type: \n" +
                     "1. SciFi\n" +
                     "2. RomCom\n" +
                     "3. Indie\n" +
                     "4. Bromance\n" +
                     "5. Action\n" +
                     "6. SuperHero");

            string genreAsString = Console.ReadLine().ToLower();
            int genreAsInt = int.Parse(genreAsString);
            editedContent.TypeOfGenre = (GenreType)genreAsInt;

            //Call Update method

            bool didUpdate = _contentRepo.UpdateExistingContent(oldContentTitle, editedContent);
            if (didUpdate)
            {
                Console.WriteLine("Update Successful");
            }
            else
            {
                Console.WriteLine("Opps");
            }
/*
        public  bool  UpdateExistingContent(string orginialTitle, StreamingContent newContent)
        {
            StreamingContent oldContent = GetContentByTitle(orginialTitle);
            if (oldContent != null)
            {
                oldContent.Title = newContent.Title;
                oldContent.Description = newContent.Description;
                oldContent.MaturityRating = newContent.MaturityRating;
                oldContent.IsFamilyFriendly = newContent.IsFamilyFriendly;
                oldContent.StarRating = newContent.StarRating;
                oldContent.TypeOfGenre = newContent.TypeOfGenre;
                return true;
            }
            else
                return false;
*/

        }

        //Seed Method
        private void SeedContentList()
        {
            StreamingContent seedContent1 = new StreamingContent("The Matrix", "Future with machines.", "PG", 3.7, true, GenreType.SciFi);
            _contentRepo.AddContentToList(seedContent1);
            StreamingContent seedContent2 = new StreamingContent("Airplane", "Laughs on a plane.", "PG", 2.7, true, GenreType.Action);
            _contentRepo.AddContentToList(seedContent2);
            StreamingContent seedContent3 = new StreamingContent("Snakes", "Snakes on a plane.", "PG-13", .5, false, GenreType.Action);
            _contentRepo.AddContentToList(seedContent3);
            StreamingContent seedContent4 = new StreamingContent("Forrest Gump", "Best movie ever", "PG", 5, true, GenreType.SuperHero);
            _contentRepo.AddContentToList(seedContent4);

            Console.WriteLine("\nlist seeded!!");

           // seedContent2 = seedContent1;
           // _contentRepo.AddContentToList(seedContent2);
           // seedContent1.Title = "Bladerunner";
           // _contentRepo.AddContentToList(seedContent1);


        }

    }
}
