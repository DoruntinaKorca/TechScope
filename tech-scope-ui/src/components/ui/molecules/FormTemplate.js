import React from "react";
import { Form } from "react-bootstrap";
import StandardButton from "../atoms/StandardButton";
import styled from "styled-components";
import { useState } from "react";
import axios from "axios";
import { useHistory } from "react-router-dom";

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
  const [courseTitle, setCourseTitle] = useState("");
  const [courseDescription, setCourseDescription] = useState("");
  const [courseCreated, setCourseCreated] = useState(false);
  const [videoTitle, setVideoTitle] = useState("");
  const [videoDescription, setVideoDescription] = useState("");
  const [videoLength, setVideoLength] = useState(0);
  const [file, setFile] = useState(null);
  const history = useHistory();

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
            history.push("/login");
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
          localStorage.setItem("token", response.data.token);
          localStorage.setItem("username", response.data.userName);
          localStorage.setItem("userid", response.data.id);
          history.push("/welcome-page");
        }
      })
      .catch(function (error) {
        setLoginError(true);
        console.log(error);
      });
  };

  const submitNewCourse = async (e) => {
    e.preventDefault();
    let userId = localStorage.getItem("userid");
    await axios
      .post(`http://localhost:5000/api/Courses/${userId}`, {
        courseTitle: courseTitle,
        courseDescription: courseDescription,
        dateUploaded: "2022-02-01T20:22:39.131Z",
        dateModified: "2022-02-01T20:22:39.131Z",
        courseViews: 0,
        courseRating: 0,
        courseApprovedBy: 0,
      })
      .then((response) => {
        setCourseCreated(true);
      })
      .catch((e) => console.log(e));
  };

  const submitNewVideo = async (e) => {
    e.preventDefault();
    await axios
      .post(
        "http://localhost:5000/api/Videos/4d37ce9b-7224-4699-80e9-49aee9522dfb",
        {
          videoTitle: videoTitle,
          videoDescription: videoDescription,
          videoLength: videoLength,
        }
      )
      .then((response) => {
        console.log(response);
        const formData = new FormData();
        formData.append("file", file);
        axios({
          method: "post",
          url: "http://localhost:5000/api/Videos/add",
          data: formData,
          headers: { "Content-Type": "multipart/form-data" },
        })
          .then((response) => console.log(response))
          .catch((err) => console.log(err));
      })
      .catch((err) => console.log(err));
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
        <Form onSubmit={(e) => submitNewVideo(e)} encType="multipart/form-data">
          <Form.Group className="mb-3"></Form.Group>
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <StyledLabel>Title</StyledLabel>
            <Form.Control
              type="text"
              placeholder="Enter Title"
              onChange={(e) => setVideoTitle(e.target.value)}
            />
          </Form.Group>
          <Form.Group className="mb-3">
            <StyledLabel>Description</StyledLabel>
            <Form.Control
              type="text"
              placeholder="Enter Description"
              onChange={(e) => setVideoDescription(e.target.value)}
            />
          </Form.Group>
          <Form.Group className="mb-3">
            <StyledLabel>Enter Video Length</StyledLabel>
            <Form.Control
              type="text"
              placeholder="Enter Video Length"
              onChange={(e) => setVideoLength(e.target.value)}
            />
          </Form.Group>
          <Form.Group controlId="formFile" className="mb-3">
            <StyledLabel>Upload Video</StyledLabel>
            <Form.Label>Default file input example</Form.Label>
            <Form.Control
              type="file"
              onChange={(e) => setFile(e.target.files[0])}
            />
          </Form.Group>
          <StyledDiv>
            <StandardButton text="Submit" type="submit"></StandardButton>
          </StyledDiv>
        </Form>
      ) : (
        <Form onSubmit={(e) => submitNewCourse(e)}>
          {courseCreated ? (
            <Form.Text style={{ color: "green" }}>
              Course Created Successfully!
            </Form.Text>
          ) : (
            ""
          )}
          <Form.Group className="mb-3">
            <StyledLabel>Title</StyledLabel>
            <Form.Control
              type="text"
              placeholder="Enter Title"
              onChange={(e) => setCourseTitle(e.target.value)}
            />
          </Form.Group>
          <Form.Group className="mb-3">
            <StyledLabel>Description</StyledLabel>
            <Form.Control
              type="text"
              placeholder="Enter Description"
              onChange={(e) => setCourseDescription(e.target.value)}
            />
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
