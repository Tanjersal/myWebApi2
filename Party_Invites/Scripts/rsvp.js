﻿var model = {
    view: ko.observable("welcome"),
    rsvp: {
        name: ko.observable(""),
        email: "",
        willAttend: ko.observable("true")
    },
    attendees: ko.observableArray([])
}

var showForm = function () {
    model.view("form");
}

var sendRsvp = function () {
    $.ajax("/api/rsvp", {
        type: "POST",
        data: {
            name: model.rsvp.name(),
            email: model.rsvp.email(),
            willAttend: model.willAttend()
        },
        success: function () {
            getAttendees()
        }
    })
};

var getAttendees = function () {
    $.ajax("/api/rsvp", {
        type: "GET",
        success: function (data) {
            model.attendees.removeAll();
            model.attendees.push.apply(model.attendees, data.map(function (rsvp) {
                return rsvp.name;
            }));
            model.view("thanks");
        }
    })
}

$(document).ready(function () {
    ko.applyBindings();
})