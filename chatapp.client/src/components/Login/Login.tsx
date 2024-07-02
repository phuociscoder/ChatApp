import React, { useState } from 'react';
import './login.css';

import { Button, Container, Row, Col, Form } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { UserLogin } from '../../services/authService';
import { useNavigate } from "react-router-dom";


function Login(){
   const [userName, setUserName] = useState('');
   const [password, setPassword] = useState('');
   const [userID, setUserID] = useState(0);
   const navigate = useNavigate();

   const onLoginClick =() => {
      UserLogin('/Login', userName, password).then(r => {
         localStorage.setItem("UserName", r.username);
         localStorage.setItem("Token", r.token);
         localStorage.setItem("UserID", r.token);
         navigate('/dashboard');
      }, e=> {});

   }
   return (
      <>
      <Form className='login-form'>
         <h1 className='mb-3'>CHAT APPLICATION</h1>
      <Form.Group className="mb-3" controlId="formGroupEmail">
        <Form.Control type="text" placeholder="User Name" value={userName} onChange={e => setUserName(e.target.value)}></Form.Control>
      </Form.Group>
      <Form.Group className="mb-3" controlId="formGroupPassword">
        <Form.Control type="password" placeholder="Password" value={password} onChange={(e) => {setPassword(e.target.value)}} />
      </Form.Group>
      <Form.Group className="mb-3" controlId="formGroupLogin">
      <Button onClick={onLoginClick}>Login</Button>
      </Form.Group>
      
      <Link to={"/register"} >Create new account</Link>
    </Form>
    </>
   )
};

export default Login;
