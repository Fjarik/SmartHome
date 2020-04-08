import { NextPage } from "next";
import Layout from "../../../components/Layouts/Layout";
import withUser from "../../../lib/withUser";
import Projects from "../../../components/Projects/Projects";

const ProjectsPage: NextPage = () => {
    return (
        <Layout title="Aplikace">
            <Projects />
        </Layout>
    );
};

export default withUser(ProjectsPage);
