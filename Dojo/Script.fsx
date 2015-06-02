#r "System.Xml.Linq.dll"
#r "packages/FSharp.Data.2.2.2/lib/net40/FSharp.Data.dll"
open FSharp.Data

// ------------------------------------------------------------------
// WORD #1
//
// Use the WorldBank type provider to get all countries in the 
// "North America" region, then find country "c" with the smallest
// "Life expectancy at birth, total (years)" value in the year 2000
// and return the first two letters of the "c.Code" property
// ------------------------------------------------------------------

// Create connection to the WorldBank service
let wb = WorldBankData.GetDataContext()
// Get specific indicator for a specific country at a given year
wb.Countries.``Czech Republic``.Indicators.``Population, total``.[2000]
// Get a list of countries in a specified region
wb.Regions.``Euro area``.Countries


// ------------------------------------------------------------------
// WORD #2
//
// Read the RSS feed in "data/bbc.xml" using XmlProvider and return
// the last word of the title of an article that was published at
// 9:05am (the date does not matter, just hours & minutes)
// ------------------------------------------------------------------

// Create a type for working with XML documents based on a sample file
type Sample = XmlProvider<"data/Writers.xml">
// Load the sample document - explore properties using "doc."
let doc = Sample.GetSample()

// ------------------------------------------------------------------
// WORD #3
//
// Get the ID of a director whose name contains "Haugerud" and then
// search for all movie credits where he appears. Then return the 
// second (last) word from the movie he directed in 2012 (the resulting 
// type has properties "Credits" and "Crew" - you need movie from the 
// Crew list.
// ------------------------------------------------------------------

// Using The MovieDB REST API
// Make HTTP request to /3/search/person
let key = "6ce0ef5b176501f8c07c634dfa933cff"
let name = "craig"
let data = 
  Http.RequestString
    ( "http://api.themoviedb.org/3/search/person",
      query = [ ("query", "craig"); ("api_key", key) ],
      headers = [ HttpRequestHeaders.Accept HttpContentTypes.Json ] )

// Parse result using JSON provider
// (using sample result to generate types)
type PersonSearch = JsonProvider<"data/personsearch.json">
let sample = PersonSearch.Parse(data)

let first = sample.Results |> Seq.head
first.Name

// Request URL: "http://api.themoviedb.org/3/person/<id>/movie_credits
// (You can remove the 'query' parameter because it is not needed here;
// you need to put the director's ID in place of the <id> part of the URL)

// Use JsonProvider with sample file "data/moviecredits.json" to parse


// ------------------------------------------------------------------
// WORD #4
//
// Use CsvProvider to parse the file "data/librarycalls.csv" which
// contains information about some PHP library calls (got it from the
// internet :-)). Note that the file uses ; as the separator.
//
// Then find row where 'params' is equal to 2 and 'count' is equal to 1
// and the 'name' column is longer than 6 characters. Return first such
// row and get the last word of the function name (which is separated
// by underscores). Make the word plural by adding 's' to the end.
// ------------------------------------------------------------------

// Demo - using CSV provider to read CSV file with custom separator
type Lib = CsvProvider<"data/mortalityny.tsv", Separators="\t">
// Read the sample file - explore the collection of rows in "lib.Data"
let lib = new Lib()

// NOTE: The librarycalls.csv file uses ';' as the separator!

// ------------------------------------------------------------------
// WORD #5
//
// In addition to XML, JSON and CSV, the F# Data library can also
// parse HTML tables! Use the HtmlProvider to read data from wiki
// page with chemical elements (or use local 'data/elements.html'):
//   - http://en.wikipedia.org/wiki/List_of_elements
//
// Your task is to find chemical element with "Atomic number" equal 
// to 36 (column 'Z' of the table) and then return the 3rd and 2nd 
// letter from the *end* of its name (that is 5th and 6th letter
// from the start).
// ------------------------------------------------------------------

// Use HtmlProvider with "data/elements.html" file as a sample

// ------------------------------------------------------------------
// WORD #6
//
// Use CsvProvider to load the Titanic data set from "data/Titanic.csv"
// (using the default column separator) and find the name of a female
// passenger who was 19 years old and embarked in the prot marked "Q"
// Then return Substring(19, 3) from her name.
// ------------------------------------------------------------------

// Use CsvProvider with the "data/titanic.csv" file as a sample

// ------------------------------------------------------------------
// WORD #7
//
// Using the same RSS feed as in Word #2 ("data/bbc.xml"), find
// item that contains "Duran Duran" in the title and return the
// 14th word from its description (split the description using ' '
// as the separator and get item at index 13).
// ------------------------------------------------------------------

// (...)
