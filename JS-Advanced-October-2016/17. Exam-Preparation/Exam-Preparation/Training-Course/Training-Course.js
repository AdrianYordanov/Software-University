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