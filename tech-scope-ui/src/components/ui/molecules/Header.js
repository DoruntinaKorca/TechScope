import React from "react";
import {
  Navbar,
  Container,
  Nav,
  Col,
  Row,
  NavDropdown,
  Button,
} from "react-bootstrap";
import { Link } from "react-router-dom";
import styled from "styled-components";

const StyledDiv = styled.div`
  display: flex;
  justify-content: space-between;
  color: black;
`;

const Header = ({ isLoggedIn }) => {
  return (
    <Navbar expand="lg" style={{ backgroundColor: "#ec7300" }}>
      <Container>
        <Navbar.Brand as={Link} to="/">
          Tech Scope
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            {!isLoggedIn ? (
              <>
                <Nav.Link as={Link} to="register">
                  Home
                </Nav.Link>
                <Nav.Link href="#link">About</Nav.Link>
              </>
            ) : (
              <>
                <Nav.Link as={Link} to="upload-video">
                  Courses
                </Nav.Link>
                <Nav.Link as={Link} to="welcome-page">
                  My Profile
                </Nav.Link>
              </>
            )}
          </Nav>
          {!isLoggedIn ? (
            <StyledDiv>
              <Nav.Link as={Link} to="login" style={{ color: "black" }}>
                Login
              </Nav.Link>
              <Nav.Link as={Link} to="register" style={{ color: "black" }}>
                Register
              </Nav.Link>
            </StyledDiv>
          ) : (
            ""
          )}
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default Header;
