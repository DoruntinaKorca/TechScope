import React from "react";
import styled from "styled-components";
import { Row, Col, Button, Container } from "react-bootstrap";
import Course from "../molecules/Course";

const Home = () => {
  return (
    <Container fluid>
      <Row>
        <Col
          style={{
            display: "flex",
            flexDirection: "column",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          <Course title="Title" description="desc" author="John Doe" />
          <Course title="Title" description="desc" author="John Doe" />
          <Course title="Title" description="desc" author="John Doe" />
          <Course title="Title" description="desc" author="John Doe" />
          <Course title="Title" description="desc" author="John Doe" />
        </Col>
      </Row>
    </Container>
  );
};

export default Home;
