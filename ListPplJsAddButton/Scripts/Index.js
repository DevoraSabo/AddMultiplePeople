$(() => {
    let num = 0;
    $("#add-another").on('click', function () {
        num++;
        $("#additional-ppl").append(` <div class="col-md-4">
                    <input type="text" placeholder="First Name" name="people[${num}].firstname" class="form-control" />
                </div>
                <div class="col-md-4">
                    <input type="text" placeholder="Last Name" name="people[${num}].lastname" class="form-control" />
                </div>
                <div class="col-md-4">
                    <input type="text" placeholder="Age" name="people[${num}].age" class="form-control" />
                </div>`);
    });
});