import React, { useState, useEffect } from "react";
import styled from "styled-components";

const StyledCard = styled.div`
  width: 300px;
  min-hegiht: 200px;
  display: flex;
  flex-direction: column;
  border: 1px solid #ef7300;
  border-radius: 25px;
  justify-content: center;
  align-items: center;
  background-color: transparent;
  margin-right: 50px;
  margin-top: 50px;
  cursor: pointer;
  transition: transform 0.5s ease-in;
  &:hover {
    transform: scale(1.1);
  }
  text-align: center;
`;
const PreferenceCard = ({ selected, text, click }) => {
  useEffect = (() => {}, [selected]);
  return (
    <StyledCard
      style={{
        minHeight: "200px",
        border: `${selected ? "3px solid #ADD8E6" : "1px solid #ef7300"}`,
      }}
      onClick={() => click(text)}
    >
      <h3 style={{ color: "white" }}>{text}</h3>
    </StyledCard>
  );
};

export default PreferenceCard;
