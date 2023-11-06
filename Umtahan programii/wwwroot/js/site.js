$(document).ready(function () {
    var subjectSelect = $("#SubjectCode");
    var studentSelect = $("#StudentId");

    var studentSubjectMapping = @Html.Raw(Json.Serialize(ViewBag.StudentSubjectMapping));

    onclik(){
        console.log(this.studentSelect)
    }

    subjectSelect.on("change", function () {
        var selectedSubject = $(this).val();

        studentSelect.empty();
        studentSelect.append($('<option>', {
            value: "",
            text: "Student Select",
            class: "text-muted",
            disabled: true,
            selected: true
        }));

        if (selectedSubject) {
            var studentsForSubject = studentSubjectMapping.filter(function (item) {
                return item.SubjectCode === selectedSubject;
            });

            studentsForSubject.forEach(function (student) {
                studentSelect.append($('<option>', {
                    value: student.Student.StudentId,
                    text: student.Student.FullName
                }));
            });
        }
    });

    subjectSelect.trigger("change");
});