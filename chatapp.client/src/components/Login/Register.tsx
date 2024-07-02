import React, { useState } from 'react';
import './login.css';
import { Store } from 'react-notifications-component';

import { Button, Container, Row, Col, Form } from 'react-bootstrap';
import { RegisterNewUser, UserLogin } from '../../services/authService';
import { useNavigate } from "react-router-dom";


function Register(){
   const [userName, setUserName] = useState('');
   const [password, setPassword] = useState('');
   const navigate = useNavigate();

   const onRegisterClick =() => {
      RegisterNewUser('/Login/register', userName, password).then(r => {
         Store.addNotification({
            title: "Wonderful!",
            message: "Create new user account successful",
            type: "success",
            insert: "top",
            container: "top-center",
            animationIn: ["animate__animated", "animate__fadeIn"],
            animationOut: ["animate__animated", "animate__fadeOut"],
            dismiss: {
              duration: 5000,
              onScreen: true
            }
          });
          navigate('/login');
      }, e=> {
         Store.addNotification({
            title: "Oops",
            message: "User account has existing",
            type: "danger",
            insert: "top",
            container: "top-center",
            animationIn: ["animate__animated", "animate__fadeIn"],
            animationOut: ["animate__animated", "animate__fadeOut"],
            dismiss: {
              duration: 5000,
              onScreen: true
            }
          });
      });

   }
   return (
      <>
      <Form className='login-form'>
         <h1 className='mb-3'>REGISTER NEW USER</h1>
      <Form.Group className="mb-3" controlId="formGroupEmail">
        <Form.Control type="text" placeholder="User Name" value={userName} onChange={e => setUserName(e.target.value)}></Form.Control>
      </Form.Group>
      <Form.Group className="mb-3" controlId="formGroupPassword">
        <Form.Control type="password" placeholder="Password" value={password} onChange={(e) => {setPassword(e.target.value)}} />
      </Form.Group>
      <Form.Group className="mb-3" controlId="formGroupLogin">
      <Button onClick={onRegisterClick}>CREATE</Button>
      </Form.Group>
    </Form>
    </>
   )
};

export default Register;
