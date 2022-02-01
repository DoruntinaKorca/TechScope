import React from "react";
import { Form } from "react-bootstrap";
import StandardButton from "../atoms/StandardButton";
import styled from "styled-components";
import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

const StyledDiv = styled.div`
  display: flex;
  justify-content: center;
`;

const StyledLabel = styled(Form.Label)`
  color: white;
`;

const FormTemplate = ({ mode }) => {
  const [regEmail, setRegEmail] = useState("");
  const [regUsername, setRegUsername] = useState("");
  const [regPassword, setRegPassword] = useState("");
  const [emailError, setEmailError] = useState(false);
  const [regConfPassword, setRegConfPassword] = useState("");
  const [passwordError, setPasswordError] = useState(false);
  const [logEmail, setLogEmail] = useState("");
  const [logPassword, setLogPassword] = useState("");
  const [loginError, setLoginError] = useState(false);

  const history = useNavigate();

  const submitRegister = async (e) => {
    e.preventDefault();
    if (
      String(regEmail)
        .toLowerCase()
        .match(
          /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
        )
    ) {
      setEmailError(false);
      if (regPassword === regConfPassword) {
        setPasswordError(false);
        await axios
          .post("http://localhost:5000/api/Account/register", {
            email: regEmail,
            username: regUsername,
            password: regPassword,
            doB: "2022-01-31T19:45:55.903Z",
          })
          .then(function (response) {
            console.log(response);
            history("/login");
          })
          .catch(function (error) {
            console.log(error);
          });
      } else {
        setPasswordError(true);
      }
    } else {
      setEmailError(true);
    }
  };

  const submitLogin = async (e) => {
    e.preventDefault();
    setLoginError(false);
    await axios
      .post("http://localhost:5000/api/Account/login", {
        email: logEmail,
        password: logPassword,
      })
      .then(function (response) {
        if (response.data.token === undefined) {
          setLoginError(true);
        } else {
          localStorage.setItem("username", response.data.userName);
          history("/welcome-page");
        }
      })
      .catch(function (error) {
        setLoginError(true);
        console.log(error);
      });
  };

  return (
    <>
      {mode === "login" ? (
        <Form onSubmit={(e) => submitLogin(e)}>
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <StyledLabel>Email address</StyledLabel>
            <Form.Control
              type="email"
              placeholder="Enter email"
              onChange={(e) => setLogEmail(e.target.value)}
            />

            {loginError ? (
              <Form.Text style={{ color: "red" }}>
                Email or password incorrect
              </Form.Text>
            ) : (
              ""
            )}
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicPassword">
            <StyledLabel>Password</StyledLabel>
            <Form.Control
              type="password"
              placeholder="Password"
              onChange={(e) => setLogPassword(e.target.value)}
            />
          </Form.Group>
          <StyledDiv>
            <StandardButton text="Login" type="submit"></StandardButton>
          </StyledDiv>
        </Form>
      ) : mode === "register" ? (
        <Form onSubmit={(e) => submitRegister(e)}>
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <StyledLabel>Email address</StyledLabel>
            <Form.Control
              type="email"
              placeholder="Enter email"
              onChange={(e) => {
                setRegEmail(e.target.value);
                console.log(e.target.value);
              }}
            />
            {emailError ? (
              <Form.Text className="text-muted">
                This email is incorrect.
              </Form.Text>
            ) : (
              ""
            )}
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <StyledLabel>Username</StyledLabel>
            <Form.Control
              type="text"
              placeholder="Enter your username"
              onChange={(e) => {
                setRegUsername(e.target.value);
                console.log(e.target.value);
              }}
            />
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicPassword">
            <StyledLabel>Password</StyledLabel>
            <Form.Control
              type="password"
              placeholder="Password"
              onChange={(e) => {
                setRegPassword(e.target.value);
                console.log(e.target.value);
              }}
            />
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicPassword">
            <StyledLabel>Confirm Password</StyledLabel>
            <Form.Control
              type="password"
              placeholder="Confirm Password"
              onChange={(e) => {
                setRegConfPassword(e.target.value);
                console.log(e.target.value);
              }}
            />
            {passwordError ? (
              <Form.Text style={{ color: "red" }}>
                Password do not match.
              </Form.Text>
            ) : (
              ""
            )}
          </Form.Group>
          <StyledDiv>
            <StandardButton text="Register" type="submit" />
          </StyledDiv>
        </Form>
      ) : mode === "video" ? (
        <Form>
          <Form.Group className="mb-3">
            <Form.Select aria-label="Select Course">
              <option>View Course</option>
              <option value="1">One</option>
              <option value="2">Two</option>
              <option value="3">Three</option>
            </Form.Select>
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <StyledLabel>Title</StyledLabel>
            <Form.Control type="text" placeholder="Enter Title" />
          </Form.Group>
          <Form.Group className="mb-3">
            <StyledLabel>Description</StyledLabel>
            <Form.Control type="text" placeholder="Enter Description" />
          </Form.Group>
          <Form.Group className="mb-3">
            <StyledLabel>Enter Video Length</StyledLabel>
            <Form.Control type="text" placeholder="Enter Video Length" />
          </Form.Group>
          <Form.Group controlId="formFile" className="mb-3">
            <StyledLabel>Upload Video</StyledLabel>
            <Form.Label>Default file input example</Form.Label>
            <Form.Control type="file" />
          </Form.Group>
          <StyledDiv>
            <StandardButton text="Submit" type="submit"></StandardButton>
          </StyledDiv>
        </Form>
      ) : (
        <Form>
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <StyledLabel>Title</StyledLabel>
            <Form.Control type="text" placeholder="Enter Title" />
          </Form.Group>
          <Form.Group className="mb-3">
            <StyledLabel>Description</StyledLabel>
            <Form.Control type="text" placeholder="Enter Description" />
          </Form.Group>
          <StyledDiv>
            <StandardButton text="Create" type="submit"></StandardButton>
          </StyledDiv>
        </Form>
      )}
    </>
  );
};

export default FormTemplate;
