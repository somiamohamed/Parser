const express = require('express');
const mongoose = require('mongoose');
const connectDB = require('./db');
const todo = require('./todo');

const app = express();
const PORT = 3000;

connectDB();
app.use(express.json());

////Endpoints////

app.get
('/todos', async (req, res) => 
  {
    try 
    {
      const todos = await todo.find();
      res.status(200).json(todos);
    } 
    catch (error) 
    {
      res.status(500).send(error.message);
    }
  }
);


app.post
('/todos', async (req, res) => 
  {
    try 
    {
      const { task } = req.body;
      const newTodo = new todo({ task });
      await newTodo.save();
      res.status(201).json(newTodo);
    } 
    catch (error) 
    {
      res.status(400).send(error.message);
    }
  }
);


app.put
('/todos/:id', async (req, res) => 
  {
    try 
    {
      const updatedTodo = await todo.findByIdAndUpdate
      (
        req.params.id, req.body,{ new: true }
      );

      if (!updatedTodo) return res.status(404).json({ message: "Todo not found" });
      
      res.status(200).json(updatedTodo);
    } 
    catch (error) 
    {
      res.status(400).send(error.message);
    }
  }
);



app.delete
('/todos/:id', async (req, res) => 
  {
    try 
    {
      const deleted = await todo.findByIdAndDelete(req.params.id);
      
      if (!deleted) return res.status(404).json({ message: "Todo not found" });
      
      res.status(204).json({ message: "Todo deleted successfully" });
    } 
    catch (error) 
    {
      res.status(400).send(error.message);
    }
  }
);

app.listen(3000, () => console.log(`Server running on port 3000`));