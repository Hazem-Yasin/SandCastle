//TODO: start section 3 
// let instructor = {
//     firstName: "Hazem",
//     isInstructor: true,
//     favoriteNumber: [3,5,6,2]
// }
// console.log(instructor.firstName);
// console.log(instructor);
// console.log("testing attention")

//section 4 - video 20
//problem solving : 
//1. Understand the problem 
//2. Explore Concrete Examples
//3. Break it down 
//4.Solve/simplify
//5. look back and refactor  


//1. Understand the problem 
//1.1 Can I restate the problem in my own words ?
//1.2 what are the inputs that go into the problem ? 
//1.3 whjat are the outputs that should come from the solution to the problem 
//1.4 can the outputs be determined from the inputs? In other words, do I have enough infomration to solve hte problem? 
//1.5 How Should I label the important pieces of data that are a part of the problem ?



//EXAMPLE: 
//1, write a function that returns two numbers 
//2. the inputs are the two numbers 
//3. the output should be one number which is the addition of the two numbers 
//4. yes the output can be determined from the input, so we can get the output which is the one number from the inputs which are the two numbers; 
var inputOne = 10;
var inputTwo = 20;
var outputOne;

//1.1 
//a counter function that counts the number of characters in the text inputted to it 
//1.2 the input should be a string
//1.3 the output should be a number 
//1.4 yes

var text = "helloooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo........................";
var count = 0;
for (var i = 0; i < text.length; i++) {
    count++;
}
console.log(count);