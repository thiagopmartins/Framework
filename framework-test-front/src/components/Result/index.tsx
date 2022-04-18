import { Heading, Stack, Text, Wrap, WrapItem } from "@chakra-ui/react"

type Props = {
  number?: number,
  divisors?: number[],
  primes?: number[]
}

export const Result = ({ number, divisors, primes }: Props) => {
  return (
    <Wrap mt={10} justify='center' w='100%'>
      <WrapItem>
        <Heading maxW='2xl' size='lg' as='h3' minW='xs' textAlign='center' color='gray.600'>Resultados</Heading>        
      </WrapItem>
      <WrapItem minW="50rem" minH="8rem" boxShadow='0 4px 8px 0 rgba(0,0,0,0.4)' borderRadius={10} padding={3} flexDirection='row'>
        <Stack>
          <Text fontSize='xl' color='gray.600'><b>Número informado:</b> {number}</Text>
          <Text fontSize='xl' color='gray.600' maxW="48rem"><b>Divisores:</b> {divisors?.join()}</Text> 
          <Text fontSize='xl' color='gray.600' maxW="48rem"><b>Primo:</b> {primes?.join()}</Text> 
        </Stack>               
      </WrapItem>       
    </Wrap>
  )
}