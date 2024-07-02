import React, { useEffect, useState } from 'react';
import { Col, Container, Row, ListGroup, Form, Button } from 'react-bootstrap';
import './dashboard.css'
import { GetListUsers } from '../../services/userService';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { useNavigate } from "react-router-dom";


interface User {
    id : number,
    username: string
}

function Dashboard(){
    const [users, SetUsers] = useState<User[]>();
    const [connection, setConnection] = useState<null | HubConnection>(null);
    const [message, setMessage] = useState('');
    const [conversations, setConversation] = useState<string[]>([]);
    const navigate = useNavigate();

const GetUsers = () => {
    GetListUsers('/user/user-list').then(r => {
        SetUsers(r);
        
    }, e=> {

    });
}

const ConnectHub =() => {
    const connection = new HubConnectionBuilder()
    .withUrl('https://localhost:7042/chatHub') 
    .build();
    setConnection(connection);
    connection.start()
    .then(() => console.log('Connected to SignalR hub'))
    .catch(err => console.error('Error connecting to hub:', err));

    connection.on('ReceiveMessage', message => {
    let listMessage = [...conversations, message];
    console.log(listMessage);
    setConversation(listMessage);
});
}

const UserElement = (model: User) => {
    return (
        <div className='w-100 p-3 mb-1 user'>
            <p>{model.username}</p>
            <Button variant='primary'>Invite</Button>
        </div>
    );
}

const SendMessage = async() => {
    let name = localStorage.getItem("UserName");
    let date = new Date();
    await connection?.send("SendMessage", name + '('+date.toLocaleString()+'): '+message);
}

    useEffect(() => {
        GetUsers();
        ConnectHub();
    }, []);


const Logout =() => {
    localStorage.removeItem("UserName");
    localStorage.removeItem("UserID");
    localStorage.removeItem("Token");
    navigate('/login');
}

    return (
        <>
        <Container className='main-container'>
            <Row className='info'>
                <Col xs={8} className='chat-session'>
                <div >
                    {conversations.map(x => <div className='w-100'>{x}</div>)}
                </div>
                </Col>
                <Col xs={4} className='user-list-container pt-1'>
                <div >
                    {users?.map(user => UserElement(user))}
                </div>
                </Col>
            </Row>
            <Row className='action'>
                <Col xs={8} className='chat-text'>
                <Form.Group className="mb-3">
                <Form.Control as="textarea" rows={5} className='mt-3' onChange={e => setMessage(e.target.value)}/>
                </Form.Group>
                </Col>
                <Col>
                <Form.Group className="mb-3 mt-3">
               <Button variant='primary' className='mr-3 w-100' onClick={SendMessage}>Send</Button>
                </Form.Group>
                <Form.Group className="mb-3 mt-3">
              
               <Button variant='warning' className='mr-3 w-100'>End Session</Button>

                </Form.Group>
                <Form.Group className="mb-3 mt-3">
            
               <Button variant='danger' className='mr-3 w-100' onClick={Logout}>Logout</Button>
                </Form.Group>
                </Col>
            </Row>
        </Container>
        </>
    );
}
export default Dashboard;