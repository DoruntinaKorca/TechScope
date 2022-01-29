import React from "react";
import { Form } from "react-bootstrap";
import StandardButton from "../atoms/StandardButton";
import styled from "styled-components";
import { useState } from "react";

const StyledDiv = styled.div`
  display: flex;
  justify-content: center;
`;

const StyledLabel = styled(Form.Label)`
  color: white;
`;

const FormTemplate = ({ mode }) => {
  return (
    <Form>
      {mode === true ? (
        <>
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <StyledLabel>Email address</StyledLabel>
            <Form.Control type="email" placeholder="Enter email" />
            <Form.Text className="text-muted">
              We'll never share your email with anyone else.
            </Form.Text>
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicPassword">
            <StyledLabel>Password</StyledLabel>
            <Form.Control type="password" placeholder="Password" />
          </Form.Group>
          <StyledDiv>
            <StandardButton text="Login" type="submit"></StandardButton>
          </StyledDiv>
        </>
      ) : (
        <>
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <StyledLabel>Email address</StyledLabel>
            <Form.Control type="email" placeholder="Enter email" />
            <Form.Text className="text-muted">
              We'll never share your email with anyone else.
            </Form.Text>
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <StyledLabel>Username</StyledLabel>
            <Form.Control type="text" placeholder="Enter your username" />
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicPassword">
            <StyledLabel>Password</StyledLabel>
            <Form.Control type="password" placeholder="Password" />
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicPassword">
            <StyledLabel>Confirm Password</StyledLabel>
            <Form.Control type="password" placeholder="Confirm Password" />
          </Form.Group>
          <StyledDiv>
            <StandardButton text="Register" type="submit"></StandardButton>
          </StyledDiv>
        </>
      )}
    </Form>
  );
};

export default FormTemplate;
