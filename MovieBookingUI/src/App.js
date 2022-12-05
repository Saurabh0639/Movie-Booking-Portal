import React, {useState} from 'react';
import axios from 'axios';
import './App.css';
import "../node_modules/bootstrap/dist/css/bootstrap.css";

function App() {

  const[user, setUser]=useState({
    username: "",
    password: ""
  });

  const{userName, password}=user;
  const onInputChange = e =>{
    setUser({...user, [e.target.name]: e.target.value});
  };

  const onSubmit = async (e) => {
    e.preventDefault();
    if(user.username === "" || user.password === ""){
      alert("All the fields are compulsory");
    }
    await axios.post("http://localhost:5120/api/user", user);
  };

  return (
    <div className="container">
      <div className="w-75 mx-auto shadow p-5">
        <h2 className="text-center mb-4">Login</h2>
        <form onSubmit={e => onSubmit(e)}>
          <div className="form-group">
            <input
              type="text"
              className="form-control form-control-lg"
              placeholder="Enter Your username"
              name="userName"
              value={userName}
              onChange={e => onInputChange(e)}
            />
          </div>
          <div className="form-group">
            <input
              type="text"
              className="form-control form-control-lg"
              placeholder="Enter Your password"
              name="password"
              value={password}
              onChange={e => onInputChange(e)}
            />
          </div>
          <button className="btn btn-primary btn-block">Login User</button>
        </form>
      </div>
    </div>
  );
}

export default App;
