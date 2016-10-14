var app = app || {};

app.lectureViews = (function () {
    function getCalendarHeaders(data, eventClickFunction) {
        return {
            theme: false,
            header: {
                left: 'prev,next today addEvent',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            defaultDate: '2016-01-12',
            selectable: false,
            editable: false,
            eventLimit: true,
            events: data,
            customButtons: {
                addEvent: {
                    text: 'Add Event',
                    click: function () {
                        Sammy(function () {
                            this.trigger('loadUrl', {url: '#/calendar/add/'})
                        });
                    }
                }
            },
            eventClick: eventClickFunction
        };
    }
    
    function showAllLecturesPage(container, lectures) {
        var eventClickFunction = function(calEvent) {
            $.get('templates/modal.html', function (templ) {
                var rendered = Mustache.render(templ, calEvent);
                $('#modal-body').html(rendered);
                $('#editLecture').remove();
                $('#deleteLecture').remove();
            });
            $('#events-modal').modal();
        };

        $.get('templates/calendar.html', function (templ) {
            $(container).html(templ);
            var headers = getCalendarHeaders(lectures, eventClickFunction);
            $('#calendar').fullCalendar(headers);
        });
    }

    function showMyLecturesPage(container, lectures) {
        var eventClickFunction = function(calEvent) {
            $.get('templates/modal.html', function (templ) {
                var rendered = Mustache.render(templ, calEvent);
                $('#modal-body').html(rendered);
                $('#editLecture').on('click', function () {
                    Sammy(function () {
                        sessionStorage['currentLecture'] = calEvent;
                        this.trigger('loadUrl', {url: '#/calendar/edit/' + calEvent._id})
                    })
                });
                $('#deleteLecture').on('click', function () {
                    Sammy(function () {
                        sessionStorage['currentLecture'] = calEvent;
                        this.trigger('loadUrl', {url: '#/calendar/delete/' + calEvent._id})
                    })
                })
            });
            $('#events-modal').modal();
        };

        $.get('templates/calendar.html', function (templ) {
            $(container).html(templ);
            var headers = getCalendarHeaders(lectures, eventClickFunction);
            $('#calendar').fullCalendar(headers);
        });
    }

    function showAddLecturePage(container) {
        $.get('templates/add-lecture.html', function (templ) {
            $(container).html(templ);
            $('#addLecture').on('click', function () {
                var lecture = {
                    title: $('#title').val(),
                    start: $('#start').val(),
                    end: $('#end').val(),
                    lecturer: sessionStorage['username']
                };

                Sammy(function () {
                    this.trigger('onAddLecture', lecture)
                })
            });
        })
    }

    function showEditLecturePage(container, lecture) {
        $.get('templates/edit-lecture.html', function (templ) {
            var rendered = Mustache.render(templ, lecture);
            $(container).html(rendered);
            $('#editLecture').on('click', function () {
                lecture.title = $('#title').val();
                lecture.start = $('#start').val();
                lecture.end = $('#end').val();
                Sammy(function () {
                    this.trigger('onEditLecture', lecture)
                })
            });
        })
    }

    function showDeleteLecturePage(container, lecture) {
        $.get('templates/delete-lecture.html', function (templ) {
            var rendered = Mustache.render(templ, lecture);
            $(container).html(rendered);
            $('#deleteLecture').on('click', function () {
                Sammy(function () {
                    this.trigger('onDeleteLecture', lecture)
                })
            });
        })
    }

    return {
        bag: {
            showAllLecturesPage: showAllLecturesPage,
            showMyLecturesPage: showMyLecturesPage,
            showAddLecturePage: showAddLecturePage,
            showEditLecturePage: showEditLecturePage,
            showDeleteLecturePage: showDeleteLecturePage
        }
    }
})();