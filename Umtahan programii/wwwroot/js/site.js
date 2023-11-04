
    //<script>
    //    // Get references to the select elements
    //    var subjectSelect = document.getElementById("subjectSelect");
    //    var studentSelect = document.getElementById("studentSelect");

    //    // Initial list of students
    //    var allStudents = @Html.Raw(Json.Serialize(ViewBag.Students));
    //    var allSubjects = @Html.Raw(Json.Serialize(ViewBag.Subjects));

    //    // Event listener for subject selection change
    //    subjectSelect.addEventListener("change", function () {
    //        // Get the selected subject's class
    //        var selectedSubjectCode = subjectSelect.value;

    //    // Filter students based on the selected subject's class
    //    var selectedSubject = allSubjects.find(function (subject) {
    //            return subject.value === selectedSubjectCode;
    //        });

    //    var selectedClass = selectedSubject.getAttribute("data-class");

    //    // Filter students based on the selected class
    //    var filteredStudents = allStudents.filter(function (student) {
    //            return student.value.indexOf(selectedClass) !== -1;
    //        });

    //        // Clear the current options in the student dropdown
    //        while (studentSelect.options.length > 0) {
    //        studentSelect.remove(0);
    //        }

    //    // Populate the student dropdown with filtered options
    //    filteredStudents.forEach(function (student) {
    //        studentSelect.options.add(new Option(student.text, student.value));
    //        });
    //    });
    //</script>

