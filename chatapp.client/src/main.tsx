import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import { ReactNotifications } from 'react-notifications-component'
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import Login from './components/Login/Login.tsx';

import 'bootstrap/dist/css/bootstrap.min.css';
import 'react-notifications-component/dist/theme.css'
import Register from './components/Login/Register.tsx';
import Dashboard from './components/Dashboard/Dashboard.tsx';

const router = createBrowserRouter([
  {
    path: "/",
    element: <App/>,
  },
  {
    path: "/login",
    element: <Login/>,
  },
  {
    path: "/register",
    element: <Register/>,
  },
  {
    path: "/dashboard",
    element: <Dashboard/>,
  },
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <ReactNotifications />
    <RouterProvider router={router} />
  </React.StrictMode>,
)
