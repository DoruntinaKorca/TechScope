import React from "react";
import styled from "styled-components";

const StyledCard = styled.div`
  display: flex;
  flex-direction: column;
  width: 400px;
  height: 180px;
  align-items: center;
  justify-content: center;
  border: 1px solid #ef7600;
  border-radius: 25px;
  margin-top: 20px;
  transition: transform 0.5s ease-in;
  cursor: pointer;
  &:hover {
    transform: scale(1.1);
  }
`;
const StyledHeader = styled.h3`
  color: white;
`;
const StyledP = styled.p`
  color: white;
`;

const Course = ({ title, description, author }) => {
  return (
    <StyledCard>
      <StyledHeader>{title}</StyledHeader>
      <StyledP>{description}</StyledP>
      <StyledP>by: {author}</StyledP>
    </StyledCard>
  );
};

export default Course;
