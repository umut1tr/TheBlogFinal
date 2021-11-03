let index = 0;

function AddTag() {

    // get refence to TagEntry input element
    var tagEntry = document.getElementById("TagEntry");

    //Lets use the new search function to help detect an error state
    let searchResult = search(tagEntry.value);
    if (searchResult != null) {
        // Trigger my sweet alert
        swalWithDarkButton.fire({
            html: `<span class='font-weight-bolger'>${searchResult.toUpperCase()}</span>`
        });
    }
    else {
        // Create a new Select Option
        let newOption = new Option(tagEntry.value, tagEntry.value);
        document.getElementById("TagList").options[index++] = newOption;
    }



    // Clear out the TagEntry control
    tagEntry.value = "";
    return true;


}


function DeleteTag() {


    let tagCount = 1;
    let tagList = document.getElementById("TagList");
    if (!tagList) return false;

    if (tagList.selectedIndex == -1) {
        swalWithDarkButton.fire({
            html: `<span class='font-weight-bolder'>CHOOSE A TAG BEFORE DELETING<\span>`
        });
        return true;
    }


    while (tagCount > 0) {

        if (tagList.selectedIndex >= 0) {
            tagList.options[tagList.selectedIndex] = null;
            --tagCount;
        }
        else
            tagCount = 0;
        index--;


    }

}

$("form").on("submit", function () {
    $("#TagList option").prop("selected", "selected");
});

//Look for the tagValues variable to see if it has data
if (tagValues != '') {

    let tagArray = tagValues.split(",");

    for (let loop = 0; loop < tagArray.length; loop++) {
        //Load up or Replace the options that we have
        ReplaceTag(tagArray[loop], loop);
        index++
    }

}

function ReplaceTag(tag, index) {
    let newOption = new Option(tag, tag);
    document.getElementById("TagList").options[index] = newOption;
}

//The Search function will detect either an empty or a duplicate Tag
//and return an error string if an error detected
function search(str) {
    if (str == "") {
        return "Empty tags are not permitted";
    }

    var tagsEl = document.getElementById("TagList");
    if (tagsEl) {
        let options = tagsEl.options;
        for (let index = 0; index < options.length; index++) {
            if (options[index].value == str)
                return `The Tag #${str} was detected as a duplicate and not permitted`
        }
    }
}

const swalWithDarkButton = Swal.mixin({

    customClass: {
        confirmButton: "btn btn-danger btn-sm btn-block btn-outline-dark"
    },
    imageUrl: "/images/Oopsbutton.jpg",
    timer: 3000,
    buttonsStyling: false
});