import { useEffect, useState } from 'react'
import { Button, Container, createStandaloneToast, FormControl, Heading, NumberInput, NumberInputField, Text, Wrap, WrapItem } from '@chakra-ui/react'
import type { NextPage } from 'next'
import { Result } from '../components/Result'
import axios from 'axios'

type DecompositionResult = {
  number: number,
  divisors: number[],
  primes: number[]
}

const Home: NextPage = () => {

  const [data, setData] = useState<DecompositionResult>()
  const [isLoading, setLoading] = useState(false)
  const [number, setNumber] = useState(1)

  const toast = createStandaloneToast()

  const handleChange = (number: number) => setNumber(number)

  const handleClick = () => {
    setLoading(true)
    axios
      .post<DecompositionResult>('http://localhost:5246/api/Decomposition/Create', {
        number: number
      })
      .then(response => {
        const { data } = response

        console.log(data)
        setData(data)
      })
      .catch(error => {
        console.log(error.response.data.errors)

        const errorMessage = JSON.stringify(error.response.data.errors)

        toast({
          title: 'An error occurred.',
          description: `${errorMessage}`,
          status: 'error',
          duration: 5000,
          isClosable: true,
        })
      })
      .finally(() => setLoading(false));
  }
  
  return (
    <Container centerContent mt={200} maxW='3xl'>
      <Wrap spacing='30px' align='center' justify='center' direction='column'>
        <WrapItem>
          <Heading maxW='2xl' size='lg' as='h3' minW='xs' textAlign='center' color='gray.600'>Insira um número para fazer decomposição</Heading>
        </WrapItem>
        <WrapItem>
          <NumberInput 
            size="lg"
            maxW='2xl' 
            minW='xs' 
            defaultValue={1} 
            min={1} 
            max={2000000000}
            focusBorderColor='brand.200'
            clampValueOnBlur={false}    
            onChange={(value) => handleChange(+value)}
          >
            <NumberInputField />
          </NumberInput>
        </WrapItem>
        <WrapItem>
          <Button 
            colorScheme='brand'
            color='white' size='lg'
            maxW='2xl' minW='xs'
            isLoading={isLoading}
            loadingText='Loading'
            _focus={{ border: '0' }}
            onClick={handleClick}
          >
            Decompor
          </Button>
        </WrapItem>

      </Wrap>
      {data?.number &&
        <Result number={data?.number} divisors={data?.divisors} primes={data?.primes} />
      }
    </Container>
  )
}

export default Home
