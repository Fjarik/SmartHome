import { NextPage } from 'next';
import Layout from "../components/Layouts/Layout";
import HomePage from '../components/HomePage/HomePage';

const Index: NextPage = () => {
  return (
    <Layout title="Hlavní stránka">
      <HomePage />
    </Layout>
  );
}

export default Index;
