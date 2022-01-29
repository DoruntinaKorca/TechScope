import React from "react";
import { Button } from "react-bootstrap";
import styled from "styled-components";

const StyledButton = styled(Button)`
  border: 1px solid #ec7300;
  background-color: #ec7300;
`;

const StandardButton = ({ text, type }) => {
  return <StyledButton type={type}>{text}</StyledButton>;
};

export default StandardButton;
