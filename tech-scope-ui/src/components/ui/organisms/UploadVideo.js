import React, { useState, useEffect } from "react";
import FormTemplate from "../molecules/FormTemplate";
import { Container, Row, Col } from "react-bootstrap";
import styled from "styled-components";

const StyledFormContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
`;

const StyledText = styled.h2`
  color: white;
`;
const UploadVideo = () => {
  return (
    <Container fluid style={{ height: "100%" }}>
      <Row style={{ height: "inherit" }}>
        <Col xs={3}></Col>
        <Col
          xs={6}
          style={{
            height: "100%",
            display: "flex",
            flexDirection: "column",
            justifyContent: "center",
            alignItems: "center",
            paddingBottom: "10vh",
          }}
        >
          <StyledFormContainer>
            <StyledText>Please submit video.</StyledText>
            <FormTemplate mode="video" />
          </StyledFormContainer>
        </Col>
        <Col xs={3}></Col>
      </Row>
    </Container>
  );
};

export default UploadVideo;
