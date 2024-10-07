// Exercise #6 - a re-do of exercise #4 plus fetch JSON from GitHub and
// allow the user to add an inputted user and clear storage

$(() => {

    fetch('https://api.example.com/data') // Replace with your API URL
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            console.log('Success:', data);
        })
        .catch(error => {
            console.error('Error:', error);
        });

}); // jQuery routine - operates as an IIFE (Immediately Invoked Function Expression)