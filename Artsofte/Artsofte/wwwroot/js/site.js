$(document).ready(function () {

    $('.departament').on('change', function () {
        const id = $(this).val()
        let p = ""
        fetch(`/Employee/GetProgammingLanguage/${id}`)
            .then(res => res.json())
            .then(data => {

                $.each(data, function (key, val) {

                    p += ` <option value="${val.id}" >${val.name
                        }</option>`

                });
                $(".programming").html(p)
            })
    });


    const Names = ["Jony","Tom","luci","jabesm","mark","paul","donald","steewen","adwerd","ason","jacop","eric"]

    $("#Name").autocomplete(
        {
            source: Names
        },
        {}

    )
})
