"use strict";

class MailBox {
    constructor() {
        this.box = [];
        this._boxWithObject = [];
    }

    addMessage(subject, text) {
        this.box.push(subject + text);
        this._boxWithObject.push({subject: subject, text: text});
        return this;
    }

    get messageCount() {
        return this.box.length;
    }

    deleteAllMessages() {
        this.box = [];
        this._boxWithObject = [];
    }

    findBySubject(substr) {
        return this._boxWithObject
            .filter(element => element.subject.indexOf(substr) !== -1);
    }

    toString() {
        if(this._boxWithObject == 0) {
            return " * (empty mailbox)";
        }

        return this._boxWithObject
            .map(element => `* [${element.subject}] ${element.text}`)
            .join("\n");
    }
}

let mb = new MailBox();
console.log("Msg count: " + mb.messageCount);
console.log('Messages:\n' + mb);
mb.addMessage("meeting", "Let's meet at 17/11");
mb.addMessage("beer", "Wanna drink beer tomorrow?");
mb.addMessage("question", "How to solve this problem?");
mb.addMessage("Sofia next week", "I am in Sofia next week.");
console.log("Msg count: " + mb.messageCount);
console.log('Messages:\n' + mb);
console.log("Messages holding 'rakiya': " +
    JSON.stringify(mb.findBySubject('rakiya')));
console.log("Messages holding 'ee': " +
    JSON.stringify(mb.findBySubject('ee')));

mb.deleteAllMessages();
console.log("Msg count: " + mb.messageCount);
console.log('Messages:\n' + mb);

console.log("New mailbox:\n" +
    new MailBox()
        .addMessage("Subj 1", "Msg 1")
        .addMessage("Subj 2", "Msg 2")
        .addMessage("Subj 3", "Msg 3")
        .toString());
