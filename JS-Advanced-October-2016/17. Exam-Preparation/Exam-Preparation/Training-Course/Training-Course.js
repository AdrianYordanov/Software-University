"use strict";

class TrainingCourse {
    constructor(title, trainer) {
        this.title = title;
        this.trainer = trainer;
        this._topics = [];
    }

    addTopic(title, date) {
        this._topics.push({title: title, date: date});
        this._topics = this._topics.sort((a, b) =>  new Date(a.date) - new Date(b.date));

        return this;
    }

    get firstTopic() {
        return this._topics[0];
    }

    get lastTopic() {
        return this._topics[this._topics.length - 1];
    }

    toString() {
        let result = `Course "${this.title}" by ${this.trainer}\n`;

        if (this._topics.length > 0) {
            result += this._topics
                .map(topic => ` * ${topic.title} - ${topic.date}`)
                .join("\n");
        }

        return result;
    }
}

let js = new TrainingCourse("JS Intro", "Svetlin Nakov");
console.log("First topic: " + JSON.stringify(js.firstTopic));
console.log("Last topic: " + JSON.stringify(js.lastTopic));
console.log("" + js);

js.addTopic("Maps", new Date(2016, 9, 6, 18, 0));
js.addTopic("JS Overview", new Date(2016, 8, 27, 18, 0));
js.addTopic("Program Logic", new Date(2016, 8, 29, 18, 0));
js.addTopic("Arrays", new Date(2016, 9, 3, 18, 0));
console.log("First topic: " + JSON.stringify(js.firstTopic));
console.log("Last topic: " + JSON.stringify(js.lastTopic));
console.log("" + js);

let php = new TrainingCourse("PHP Intro", "Ivan Yonkov")
    .addTopic("Strings", new Date(2017, 2, 16, 18, 0))
    .addTopic("PHP First Steps", new Date(2017, 2, 12, 18, 0))
    .addTopic("Arrays", new Date(2017, 2, 14, 18, 0));
console.log("" + php);
