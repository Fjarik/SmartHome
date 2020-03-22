import Link from 'next/link'
import Layout from '../components/Layout'
import SocialButton from '../components/Login/SocialButton'

const googleLoginSuccess = async (user: any) => {
  // const email: string = user._profile.email;
  // const name: string = user._profile.name;
  // // const provider: AuthType = AuthType.GOOGLE;
  // const token: string = user._profile.id;
  // const theme: string = user._profile.theme;

  console.log(user._token.accessToken);
  // await externalLogin(email, name, provider, token, theme);
};
const onExternalLoginFail = async (error: any) => {
  console.log(error);
};

const IndexPage = () => (
  <Layout title="Home | Next.js + TypeScript Example">
    <h1>Hello Next.js 👋</h1>
    <p>
      <Link href="/about">
        <a>About</a>
      </Link>
      <SocialButton appId="1080634695580-t83muhrjtdvnk0jf12kuerh30l2pclpu.apps.googleusercontent.com"
        provider="google"
        onLoginSuccess={googleLoginSuccess}
        onLoginFailure={onExternalLoginFail}
      >
        Příhlásit se
      </SocialButton>
    </p>
  </Layout>
)

export default IndexPage
