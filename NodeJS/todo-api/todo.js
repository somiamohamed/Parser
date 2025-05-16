const mongoose = require('mongoose');

const todoSchema = new mongoose.Schema
(
     {
          task: 
          {
               type: String,
               required: true
          },
          done: 
          {
               type: Boolean,
               default: false
          }
     }
);

const todo = mongoose.model('todo', todoSchema);
module.exports = todo;
