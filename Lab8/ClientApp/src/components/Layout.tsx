import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';

type Props = {
  children: JSX.Element
};

const Layout = ({ children }: Props) => {
  return (
    <div>
      <NavMenu />
      <Container>
        {children}
      </Container>
    </div>
  );
};

export default Layout;
