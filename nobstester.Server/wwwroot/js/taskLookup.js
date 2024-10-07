$(() => {
    console.log("it's working")// main jQuery routine - executes every on page load, $ is short for jquery
    $("#getbutton").on('click', async (e) => { // click event handler makes aysynchronous fetch
        try {
            let name = $("#TextBoxname").val();
            $("#status").text("please wait...");
            let response = await fetch(`/api/Task/${name}`);
            if (response.ok) {
                let data = await response.json(); // this returns a promise, so we await it
                console.log(data); 
                if (data.name !== "not found") {
                    $("#id").text(data.id);
                    $("#description").text(data.description);
                    $("#iscomplete").text(data.iscompleted);
                    $("#duedate").text(data.duedate);
                    $("#status").text("Task found");
                } else {
                    $("#duedate").text("not found");
                    $("#iscomplete").text("not found");
                    $("#description").text("not found");
                    $("#id").text("not found");
                    $("#status").text("No Task Found");
                }
            } else if (response.status !== 404) { // probably some other client side error
                let problemJson = await response.json();
                errorRtn(problemJson, response.status);
            } else { // else 404 not found
                $("#status").text("no such path on server");
            } // else
        } catch (error) { // catastrophic
            $("#status").text(error.message);
        } // try/catch
    }); // click event
}); // main jQuery method
// server was reached but server had a problem with the call
const errorRtn = (problemJson, status) => {
    if (status > 499) {
        $("#status").text("Problem server side, see debug console");
    } else {
        let keys = Object.keys(problemJson.errors)
        problem = {
            status: status,
            statusText: problemJson.errors[keys[0]][0], // first error
        };
        $("#status").text("Problem client side, see browser console");
        console.log(problem);
    } // else
}
