
//Annette Hawks
//Due 7/23/2025
//Mad Libs 2 


//Main Code
//Build the dictonary frame
//args
//for each loops
//pull out words from the story as strings to evaluate and determine where they go
//(like last mad libs). Splitting the lines into words and checking for ::
//use key and values to replace the words
// make sure there are no duplicate words
// build a random word puller (like a random number generator)
// console read/writeline information to allow someone to choose story one or two
//^ this will act as a test to make sure it is acting right
// display the story before saving it to a new file. 


//Methods
//1. Build a dictionary of categories from story1 and story2
//a. Go through the story once
//b. find all the categories ie. wolf::noun (word::category)
//c. take the category: noun and put into a dictionary with unique words 

//2. Take the category and replace the word with a word from the matching category
//a. Go through the story a second time to do that. 
//b. Save the story with the new words into a new file. 

//Flow Chart
//Main Code
//Start 
//v
//get file names from args
//v
//for each file name in args then
//v
//call method BuildCatDictionary 
//> returns: Dictionary strings, list etc
//v
//call method NewWords 
//> returns: replace story string
//v 
//console writeline: user chooses 1 or 2 to generate new story 
//this tests visually if it is working
//v
//save generated story as "newstory.filename 

//Method: BuildCatDictionary
//
//START
//v
// read the file line by line
//v
//For Each line
//v
//split into words
//v 
//for each word
//if word contains :: then 
// divide word and category... split
//if category is !NOT already in the dictionary 
//then add it with a new list<string>
//if word is !NOT in the category's list
//then add the word to the list
//return dictionary 

//Method 2 NewWords
//START
//v
//read file (whole story1 and story 2 respectively)
//v
//split story into words
//v
//For Each word
//IF the word contains :: then
//split into original word, category
//get the list of words for said category from the dictionary. 
//pick a random word from the dictionary
//replace the word with the new word
//join it back together into one string. 
//return: Put the story back together
