const mongoose = require('mongoose');
const uri = process.env.MONGO_URL || 'mongodb://localhost:27017/todo-app';

const connectDB = async () => 
{
  try 
  {
    await mongoose.connect
    (uri, {useNewUrlParser: true, useUnifiedTopology: true,});
    
    console.log("MongoDB Connected");
  } 
  catch (error) 
  {
    console.error(error.message);
    process.exit(1);
  }
};

module.exports = connectDB;